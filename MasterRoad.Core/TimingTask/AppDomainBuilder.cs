using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MasterRoad.Core.TimingTask
{
    public class AppDomainBuilder
    {
        private static readonly Dictionary<String, AppDomain> _taskDomains
            = new Dictionary<String, AppDomain>();

        private static readonly Dictionary<String, Object> _taskInstances
            = new Dictionary<String, Object>();

        /// <summary>
        /// 隔离加载模块
        /// </summary>
        /// <param name="taskEntryPath">模块执行入口，***.dll或***.exe</param>
        /// <returns></returns>
        public static object Build(string taskEntryPath, string assemblyFullName, string typeFullName)
        {
            object result;

            if (_taskInstances.TryGetValue(taskEntryPath, out result))
            {
                return result;
            }

            AppDomain domain;

            if (!_taskDomains.TryGetValue(taskEntryPath, out domain))
            {
                FileInfo f = new FileInfo(taskEntryPath);

                if (!f.Exists)
                {
                    throw new FileNotFoundException("不存在", f.FullName);
                }

                if (!new[] { ".dll", ".exe" }.Contains(f.Extension.ToLower()))
                {
                    throw new BadImageFormatException("不支持此类型文件", f.FullName);
                }

                string configFile = System.IO.Path.Combine(f.DirectoryName, f.Name + ".config");

                var setup = new AppDomainSetup();

                if (File.Exists(configFile))
                {
                    setup.ConfigurationFile = configFile;
                }

                setup.ApplicationBase = f.DirectoryName;
                setup.PrivateBinPath = f.DirectoryName;

                domain = AppDomain.CreateDomain(taskEntryPath, null, setup);

                _taskDomains.Add(taskEntryPath, domain);
            }

            result = domain.CreateInstanceAndUnwrap(assemblyFullName, typeFullName);

            _taskInstances.Add(taskEntryPath, result);

            return result;
        }
    }
}