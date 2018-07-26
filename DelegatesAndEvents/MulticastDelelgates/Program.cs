using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelelgates
{
    class Program
    {
        public static void MethodOne()
        {
            Console.WriteLine("Method one");
        }
        public static void MethodTwo()
        {
            Console.WriteLine("Method Two");
        }
        public delegate void Del();
        static void Main(string[] args)
        {
            Del d = MethodOne;
            d += MethodTwo;
            d();
            Console.ReadLine();
        }
    }
}
