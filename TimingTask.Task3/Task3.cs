using MasterRoad.Core.TimingTask;
using System;

namespace TimingTask.Task3
{
    public class Task3 : BaseTimingTask
    {
        int i = 0;

        public Task3()
            : base(new AppconfigTimingTaskSettingHelper())
        {
        }

        public override TaskExecuteResult Execute()
        {
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