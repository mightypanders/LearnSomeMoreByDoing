using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadlockExample
{
    //this doesn't really work 
    class Program
    {
        static void Main(string[] args)
        {
            object lockA = new object(), lockB = new object();
            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    lock (lockB)
                    {
                        Console.WriteLine("Lock A B");
                    }
                }
            });
            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Lock B A");
                    Console.ReadKey();
                }
            }
            up.Wait();
            Console.ReadKey();
        }
    }
}
