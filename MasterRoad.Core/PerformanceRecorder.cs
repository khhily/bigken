/*
 * author:      bigken
 * function:    计算函数运行时间
 */
using System;
using System.Diagnostics;

namespace MasterRoad.Core
{
    public class PerformanceRecorder
    {
        public static void Invoke(int loopCount, params  Action[] acts)
        {
            System.Threading.Tasks.Parallel.ForEach(acts, act =>
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < loopCount; i++)
                {
                    try
                    {
                        act();
                    }
                    finally
                    {
                        //do nothing
                    }
                }

                sw.Stop();

                Console.WriteLine(string.Format("{0}\t\t{1}\t次\t{2}\t毫秒", act.Method.Name, loopCount, sw.ElapsedMilliseconds));
            });
        }
    }
}