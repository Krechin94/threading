using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    internal class ThreadPoolExample
    {
        private bool _kill;

        public ThreadPoolExample()
        {
            ThreadPool.QueueUserWorkItem(Sleep);

            ThreadPool.QueueUserWorkItem(Count);
            ThreadPool.QueueUserWorkItem(Count);
            ThreadPool.QueueUserWorkItem(Count);
            ThreadPool.QueueUserWorkItem(Count);
            ThreadPool.QueueUserWorkItem(Count);
            ThreadPool.QueueUserWorkItem(CountSeconds);

            //  Основной тред нужно заставить жить пока выполняются дочерние, иначе программа
            //  закроется, а треды уничтожаться
            Thread.Sleep(13000);
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
        private void CountSeconds(object obj)
        {
            int i = 0;
            Console.WriteLine($"Начинаю отсчет секунд:\n");
            while (true)
            {
                i++;
                Thread.Sleep(1000);
                Console.Write($"\r{i}");
            }
        }
    }
}
