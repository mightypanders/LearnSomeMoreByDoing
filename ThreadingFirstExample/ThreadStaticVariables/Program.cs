using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadStaticVariables
{
    class Program
    {
        [ThreadStatic]
        public static int _field;
        static void Main(string[] args)
        {

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                    Thread.Sleep(1);
                }
            }).Start();
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                    Thread.Sleep(1);
                }
            }).Start();
            Console.ReadKey();
        }
    }
}
