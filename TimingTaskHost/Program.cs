using MasterRoad.Core;
using MasterRoad.Core.TimingTask;
using System;

namespace TimingTaskHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CmdLineTimingTaskHost service = new CmdLineTimingTaskHost();

            service.AddTask(@"E:\我的项目\MasterRoad\TimingTask.Task2\bin\Debug\TimingTask.Task2.dll",
                    "TimingTask.Task2",
                    "TimingTask.Task2.Task2");
            service.AddTask(@"E:\我的项目\MasterRoad\TimingTask.Task3\bin\Debug\TimingTask.Task3.dll",
                    "TimingTask.Task3",
                    "TimingTask.Task3.Task3");
            service.Start();

            //PerformanceRecorder.Invoke(500, () =>
            //{
            //    var task2 = TimingTaskLoader.Load(@"E:\我的项目\MasterRoad\TimingTask.Task2\bin\Debug\TimingTask.Task2.dll",
            //        "TimingTask.Task2",
            //        "TimingTask.Task2.Task2") as ITimingTask;
            //    task2.Execute();
            //},
            //() =>
            //{
            //    var task3 = TimingTaskLoader.Load(@"E:\我的项目\MasterRoad\TimingTask.Task3\bin\Debug\TimingTask.Task3.dll",
            //        "TimingTask.Task3",
            //        "TimingTask.Task3.Task3") as ITimingTask;
            //    task3.Execute();
            //});

            Console.Read();
        }
    }
}