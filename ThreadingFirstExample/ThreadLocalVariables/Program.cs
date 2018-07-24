using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadLocalVariables
{
    class Program
    {
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                    Thread.Sleep(1);
                }
            }).Start();
            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                    Thread.Sleep(1);
                }
            }).Start();
            Console.ReadKey();
        }
    }
}
