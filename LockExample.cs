using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    // Демонстрирует работу lock(). 2 треды ждут пока третья спит секунду
    // Показывает что у очереди тредов нет порядка и они отрабатывают
    // в случайном порядке.
    internal class LockExample
    {
        object sync = new object();

        public LockExample()
        {
            var sleeper = new Thread(SleepNahooj);
            var wruter = new Thread(WriteMessage);
            var pedik = new Thread(Tohapedik);
            sleeper.Start();
            wruter.Start();
            pedik.Start();
        }
        private void Tohapedik(object obj)
        {
            while (true)
            {
                lock (sync)
                {
                    Console.WriteLine("B");
                }
            }
        }
        private void WriteMessage(object obj)
        {
            while(true)
            {
                lock(sync)
                {
                    Console.WriteLine("A");
                }
            }
        }

        private void SleepNahooj(object obj)
        {
            while(true)
            {
                lock(sync)
                {
                    Console.WriteLine("SLEEP");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
