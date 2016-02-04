using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MasterRoad.Core.TimingTask
{
    public class CmdLineTimingTaskHost
    {
        private System.Threading.Timer timer;
        private readonly List<BaseTimingTask> tasks = new List<BaseTimingTask>();

        public CmdLineTimingTaskHost()
        {
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(this.timer_tick));
        }

        public void AddTask(string taskEntryPath, string assemblyFullName, string typeFullName)
        {
            //添加新任务
            var newTask = TimingTaskLoader.Load(taskEntryPath, assemblyFullName, typeFullName);

            Debug.Assert(newTask != null);

            if (tasks.Any(x => x.TaskSetting.TaskName == newTask.TaskSetting.TaskName))
            {
                return;
            }

            this.tasks.Add(newTask);

            //向调度服务器注册自己
            //todo
        }

        private void timer_tick(object sender)
        {
            Debug.WriteLine(DateTime.Now);

            System.Threading.Tasks.Parallel.ForEach(tasks, task =>
            {
                Debug.WriteLine(task.TaskSetting.ToString());

                if (task.TaskSetting.WaitLastLoop && task.TaskSetting.IsRunning)
                {
                    //等待上次退出
                    return;
                }

                if (!task.TaskSetting.IsLoopTask && task.TaskSetting.LastExecuteTime.HasValue)
                {
                    //一次性任务并且已经执行过了
                    return;
                }

                if ((task.TaskSetting.FirstLoopTime ?? DateTime.Now) > DateTime.Now)
                {
                    //尚未到设置的开始时间
                    return;
                }

                if (task.TaskSetting.NextTime <= DateTime.Now)
                {
                    try
                    {
                        task.TaskSetting.UpdateRunStatus(true);

                        task.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(task.TaskSetting.TaskName + "\t" + ex.Message);
                    }
                    finally
                    {
                        task.TaskSetting.UpdateRunStatus(false, true);
                    }
                }
            });
        }

        public void Start()
        {
            timer.Change(0, 1000);
        }
    }
}