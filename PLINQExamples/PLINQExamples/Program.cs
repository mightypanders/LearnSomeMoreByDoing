using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var num = Enumerable.Range(0, 100000000);
            var parRes = num
                .AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();
            Console.WriteLine("output?");
            Console.ReadKey();
            foreach (var item in parRes)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
