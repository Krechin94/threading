using System;
using System.Threading;

namespace Threading
{
    internal class Program
    {
        static int elapsed = 0;
        static bool killThred = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Выберите урок.\n" +
                "\t1. Смотрим как грузится процессор от рассчетов на 4 тредах одновременно в течении 10 сек.\n" +
                "\t2. Показывает как ведут себя треды через синхронизацию при помощи lock(sync) - потоки " +
                "соперничают за вывод\n \tна консоль, передавая друг другу sync объект (блокируя его)\n" +
                "\t3. Показать работу ThreadPool - выдает потоки по мере надобности из общего пула потоков (лист тредов)");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        new CpuClockExample();
                        break;
                    }
                case "2":
                    {
                        new LockExample();
                        break;
                    }
                case "3":
                    {
                        new ThreadPoolExample();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("TI TUPOI?");
                        return;
                    }
            }
        }
    }
}
