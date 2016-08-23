using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> queue = new LimitedQueue<int>(2);

            for (int i = 0; i < 10; i++)
            {
                var tI = i;

                ThreadPool.QueueUserWorkItem(s =>
                {
                    Console.WriteLine($"Enque: {tI}");
                    queue.Enque(tI);
                    Thread.Sleep(1000);
                    Console.WriteLine($"Deque: {queue.Deque()}");
                });
            }

            Console.ReadKey();
        }
    }
}
