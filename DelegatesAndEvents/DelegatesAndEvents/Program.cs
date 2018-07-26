using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        public delegate int Calculate(int x, int y);

        public static int Multiply(int x, int y) { return x * y; }
        public static string Conc(int x, int y) { return x.ToString() + y.ToString(); }

        static void Main(string[] args)
        {
            UseDelegates();
        }

        private static void UseDelegates()
        {
            Calculate c = (x, y) =>
            {
                Console.WriteLine("Adding");
                return x + y;
            };
            Console.WriteLine(c(3, 4));
            c = Multiply;
            Console.WriteLine(c(3, 4));
            Func<int, int, int> a = Multiply;
            Console.WriteLine(a(3, 4));
            Func<int, int, string> b = Conc;
            Console.WriteLine(b(3, 4));
            Console.ReadLine();
        }
    }
}
