using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    internal class CpuClockExample
    {
        private bool _kill;

        public CpuClockExample()
        {
            var counter = new Thread(Count);
            var counter1 = new Thread(Count);
            var counter2 = new Thread(Count);
            var counter3 = new Thread(Count);
            var stoper  = new Thread(Sleep);
            counter.Start();
            counter1.Start();
            counter2.Start();
            counter3.Start();
            stoper.Start();
        }

        private void Sleep(object obj)
        {
            Thread.Sleep(10000);
            _kill = true;   
        }

        private void Count(object obj)
        {
            int i = 0;
            while (true)
            {
                i++;
                if (_kill)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}
