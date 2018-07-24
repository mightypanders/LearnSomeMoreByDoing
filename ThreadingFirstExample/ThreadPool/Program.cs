using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem((s) =>
                {
                    Console.WriteLine("Working in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                });

            }
            Console.ReadKey();
        }
    }
}
