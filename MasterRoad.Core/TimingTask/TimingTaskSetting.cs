using System;
using System.Linq;

namespace MasterRoad.Core.TimingTask
{
    /// <summary>
    /// 间隔时间单位
    /// </summary>
    public enum TimeUnit
    {
        /// <summary>
        /// 秒
        /// </summary>
        SECOND = 1,

        /// <summary>
        /// 分
        /// </summary>
        MINUTE = 2,

        /// <summary>
        /// 小时
        /// </summary>
        HOUR = 3
    }

    /// <summary>
    /// 任务设置
    /// </summary>
    public class TimingTaskSetting : MarshalByRefObject
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 是否循环性任务，默认True
        /// </summary>
        public bool IsLoopTask { get; set; }

        /// <summary>
        /// 时间单位
        /// </summary>
        public TimeUnit IntervalTimeUnit { get; set; }

        /// <summary>
        /// 循环间隔
        /// </summary>
        public int IntervalTime { get; set; }

        /// <summary>
        /// 是否等待上次任务完成后再执行该任务，默认为True
        /// </summary>
        public bool WaitLastLoop { get; set; }

        /// <summary>
        /// 设定的首次执行时间
        /// </summary>
        public DateTime? FirstLoopTime { get; set; }

        /// <summary>
        /// 出错后重试次数
        /// </summary>
        public int RetryCount { get; set; }

        public DateTime? LastExecuteTime { get; private set; }

        public void UpdateLastExecuteTime()
        {
            LastExecuteTime = DateTime.Now;
        }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public DateTime NextTime
        {
            get
            {
                if (!LastExecuteTime.HasValue)
                {
                    return DateTime.Now;
                }

                switch (this.IntervalTimeUnit)
                {
                    case TimeUnit.HOUR:
                        return LastExecuteTime.Value.AddHours(this.IntervalTime);

                    case TimeUnit.MINUTE:
                        return LastExecuteTime.Value.AddMinutes(this.IntervalTime);

                    default:
                    case TimeUnit.SECOND:
                        return LastExecuteTime.Value.AddSeconds(this.IntervalTime);
                }
            }
        }

        /// <summary>
        /// 是否正在运行
        /// </summary>
        public bool IsRunning { get; private set; }

        public void UpdateRunStatus(bool isRunning, bool updateLastExecuteTime = false)
        {
            IsRunning = isRunning;

            if (updateLastExecuteTime)
            {
                UpdateLastExecuteTime();
            }
        }

        public override string ToString()
        {
            return string.Format("{{TaskName:{0},IsLoopTask:{1},IntervalTimeUnit:{2},IntervalTime:{3},WaitLastLoop:{4},FirstLoopTime:{5},RetryCount:{6},LastExecuteTime:{7},NextTime:{8}}}",
                this.TaskName,
                this.IsLoopTask,
                this.IntervalTimeUnit,
                this.IntervalTime,
                this.WaitLastLoop,
                this.FirstLoopTime,
                this.RetryCount,
                this.LastExecuteTime,
                this.NextTime);
        }
    }

    /// <summary>
    ///任务配置助手
    /// </summary>
    public interface ITimingTaskSettingHelper
    {
        /// <summary>
        /// 读取任务配置
        /// </summary>
        /// <returns></returns>
        TimingTaskSetting Load();

        /// <summary>
        /// 保存任务配置
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        bool Save(TimingTaskSetting setting);
    }

    /// <summary>
    /// 任务配置助手实现——从配置文件中加载任务配置
    /// </summary>
    public class AppconfigTimingTaskSettingHelper : ITimingTaskSettingHelper
    {
        public TimingTaskSetting Load()
        {
            var result = new TimingTaskSetting()
            {
                FirstLoopTime = DateTime.Now,
                IntervalTime = 1,
                IntervalTimeUnit = TimeUnit.MINUTE,
                IsLoopTask = true,
                RetryCount = 0,
                TaskName = System.IO.Path.GetFileName(AppDomain.CurrentDomain.FriendlyName),
                WaitLastLoop = true
            };

            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
               AppDomain.CurrentDomain.FriendlyName/*这里的APPDOMAIN就是这么设置的*/);

            if (config == null)
            {
                return result;
            }

            if (config.AppSettings.Settings.AllKeys.Contains("FirstLoopTime"))
            {
                result.FirstLoopTime = DateTime.Parse(config.AppSettings.Settings["FirstLoopTime"].Value);
            }

            if (config.AppSettings.Settings.AllKeys.Contains("IntervalTime"))
            {
                result.IntervalTime = int.Parse(config.AppSettings.Settings["IntervalTime"].Value);
            }

            if (config.AppSettings.Settings.AllKeys.Contains("IntervalTimeUnit"))
            {
                result.IntervalTimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), config.AppSettings.Settings["IntervalTimeUnit"].Value);
            }

            if (config.AppSettings.Settings.AllKeys.Contains("IsLoopTask"))
            {
                result.IsLoopTask = bool.Parse(config.AppSettings.Settings["IsLoopTask"].Value);
            }

            if (config.AppSettings.Settings.AllKeys.Contains("RetryCount"))
            {
                result.RetryCount = int.Parse(config.AppSettings.Settings["RetryCount"].Value);
            }

            if (config.AppSettings.Settings.AllKeys.Contains("TaskName"))
            {
                result.TaskName = config.AppSettings.Settings["TaskName"].Value;
            }

            if (config.AppSettings.Settings.AllKeys.Contains("WaitLastLoop"))
            {
                result.WaitLastLoop = bool.Parse(config.AppSettings.Settings["WaitLastLoop"].Value);
            }

            return result;
        }

        public bool Save(TimingTaskSetting setting)
        {
            return true;
        }
    }
}