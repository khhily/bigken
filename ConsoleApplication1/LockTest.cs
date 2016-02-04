using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class LockTest
    {
        public void Test(int i)
        {
            lock (this)
            {
                if (i > 100)
                {
                    i--;
                    Console.WriteLine(string.Format("in lock\t{0}", i));
                    Test(i);
                }
            }

            Console.WriteLine(string.Format("out lock\t{0}", i));

            /*
             * 这个不会死锁
             */
        }
    }
}
