using MasterRoad.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApplication1
{
    public class ParallelTest
    {
        public static void Test()
        {
            Student[] Students = new Student[1000000];

            Random rd = new Random();

            for (var i = 0; i < Students.Length; i++)
            {
                Students[i] = new Student()
                {
                    ClassName = rd.Next(1, 100).ToString(),
                    StudentID = i,
                    StudentName = i.ToString()
                };
            }

            Dictionary<string, int> ClassStudentDic = new Dictionary<string, int>();

            Stopwatch sw = Stopwatch.StartNew();

            System.Threading.Tasks.Parallel.ForEach(Students, s =>
            {
                if (ClassStudentDic.ContainsKey(s.ClassName))
                {
                    ClassStudentDic[s.ClassName] += 1;
                }
                else
                {
                    ClassStudentDic[s.ClassName] = 1;
                }
            });

            sw.Stop();

            Console.WriteLine(string.Format("{0}\t\t{1}\t毫秒", "并行计算", sw.ElapsedMilliseconds));

            ClassStudentDic.Clear();

            System.Threading.Tasks.ParallelOptions option =
                new System.Threading.Tasks.ParallelOptions();

            option.MaxDegreeOfParallelism = System.Environment.ProcessorCount - 1;

            System.Collections.Concurrent.Partitioner<Student> rangePartitioner =
                System.Collections.Concurrent.Partitioner.Create<Student>(Students, true);

            sw.Restart();

            System.Threading.Tasks.Parallel.ForEach<Student, Dictionary<string, int>>(rangePartitioner,
                option,
                () => new Dictionary<string, int>(),
                (student, state, dic) =>
                {
                    if (dic.ContainsKey(student.ClassName))
                    {
                        dic[student.ClassName] += 1;
                    }
                    else
                    {
                        dic[student.ClassName] = 1;
                    }

                    return dic;
                },
                (finalDic) =>
                {
                    foreach (var item in finalDic)
                    {
                        if (ClassStudentDic.ContainsKey(item.Key))
                        {
                            ClassStudentDic[item.Key] += item.Value;
                        }
                        else
                        {
                            ClassStudentDic[item.Key] = item.Value;
                        }
                    }
                });

            sw.Stop();

            Console.WriteLine(string.Format("{0}\t\t{1}\t毫秒", "并行计算", sw.ElapsedMilliseconds));

            //foreach (var item in ClassStudentDic.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(string.Format("paral\tclass={0}\tcount={1}", item.Key, item.Value));
            //}

            ClassStudentDic.Clear();

            sw.Restart();

            foreach (var s in Students)
            {
                if (ClassStudentDic.ContainsKey(s.ClassName))
                {
                    ClassStudentDic[s.ClassName] += 1;
                }
                else
                {
                    ClassStudentDic[s.ClassName] = 1;
                }
            }

            sw.Stop();

            Console.WriteLine(string.Format("{0}\t\t{1}\t毫秒", "循环计算", sw.ElapsedMilliseconds));

            //foreach (var item in ClassStudentDic.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(string.Format("loop\tclass={0}\tcount={1}", item.Key, item.Value));
            //}

            sw.Restart();

            var dddd = Students.GroupBy(x => x.ClassName).ToList();

            sw.Stop();

            Console.WriteLine(string.Format("{0}\t\t{1}\t毫秒", "LINQ计算", sw.ElapsedMilliseconds));

            //foreach (var item in dddd.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(string.Format("linq\tclass={0}\tcount={1}", item.Key, item.Count()));
            //}
        }
    }
}