using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentBagExample
{
    class Program
    {

        static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(44);
            });

            Thread.Sleep(100);

            Task.Run(() =>
            {
                foreach (var item in bag)
                {
                    Console.WriteLine(item);
                }
            }).Wait();

            Console.ReadKey();
        }
    }
}
