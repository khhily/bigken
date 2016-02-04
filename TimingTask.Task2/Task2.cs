using MasterRoad.Core.TimingTask;
using System;

namespace TimingTask.Task2
{
    public class Task2 : BaseTimingTask
    {
        int i = 0;
        public Task2()
            : base(new AppconfigTimingTaskSettingHelper())
        {
        }

        public override TaskExecuteResult Execute()
        {
            throw new NotImplementedException();

            i += 1;

            Console.WriteLine(string.Format("{0}\t{1}\t{2}", i.ToString("0000"), DateTime.Now, this.TaskSetting.TaskName));

            return new TaskExecuteResult(TaskExecuteStatus.FINISHED, null);
        }

        public override TaskExecuteResult Cancel()
        {
            throw new NotImplementedException();
        }
    }
}