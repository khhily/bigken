using System;

namespace MasterRoad.Core.TimingTask
{
    /// <summary>
    /// 任务运行状态
    /// </summary>
    public enum TaskExecuteStatus
    {
        /// <summary>
        /// 被取消了
        /// </summary>
        CANCELED = 2,

        /// <summary>
        /// 正常完成
        /// </summary>
        FINISHED = 3,

        /// <summary>
        /// 出现异常了
        /// </summary>
        ERROR = 4
    }

    /// <summary>
    /// 任务执行结果
    /// </summary>
    public class TaskExecuteResult : MarshalByRefObject
    {
        public TaskExecuteResult(TaskExecuteStatus ts, string msg)
        {
            this.TaskStatus = ts;
            this.Message = msg;
        }

        public TaskExecuteStatus TaskStatus { get; private set; }

        public string Message { get; private set; }
    }

    /// <summary>
    /// 任务基类
    /// </summary>
    abstract public class BaseTimingTask : MarshalByRefObject
    {
        #region

        /// <summary>
        /// 任务DLL完整路径
        /// </summary>
        public string EntryPath { get; private set; }

        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblyFullName { get; private set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeFullName { get; private set; }

        public void SetTaskAsmInfo(string taskEntryPath, string assemblyFullName, string typeFullName)
        {
            this.EntryPath = taskEntryPath;
            this.AssemblyFullName = assemblyFullName;
            this.TypeFullName = typeFullName;
        }

        #endregion

        /// <summary>
        /// 任务设置
        /// </summary>
        public TimingTaskSetting TaskSetting { get; private set; }

        /// <summary>
        /// 通过构造函数注入来实例化任务配置加载类
        /// </summary>
        /// <param name="settingLoader"></param>
        public BaseTimingTask(ITimingTaskSettingHelper settingLoader)
        {
            this.TaskSetting = settingLoader.Load();
        }

        abstract public TaskExecuteResult Execute();

        abstract public TaskExecuteResult Cancel();
    }

    /// <summary>
    /// 任务加载器
    /// </summary>
    public class TimingTaskLoader
    {
        static T Load<T>(string taskEntryPath) where T : BaseTimingTask
        {
            var type = typeof(T);

            return Load(taskEntryPath, type.Assembly.FullName, type.FullName) as T;
        }

        public static BaseTimingTask Load(string taskEntryPath, string assemblyFullName, string typeFullName)
        {
            var tsk = AppDomainBuilder.Build(taskEntryPath, assemblyFullName, typeFullName) as BaseTimingTask;

            if (tsk != null)
            {
                tsk.SetTaskAsmInfo(taskEntryPath, assemblyFullName, typeFullName);

                return tsk;
            }

            return null;
        }
    }
}