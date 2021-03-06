﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            object _lock = new object();
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (_lock)
                        n++;
                    Thread.Sleep(1);
                }
            });
            for (int i = 0; i < 1000; i++)
            {
                lock (_lock)
                    n--;
                Thread.Sleep(1);
            }
            up.Wait();
            Console.WriteLine(n);
            Console.ReadKey();

        }
    }
}
