using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Parallel.For(0, 10, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, i =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("Sleeping");
              });
            Console.WriteLine("Elapsed: {0}MS", s.ElapsedMilliseconds);
            s.Restart();
            var num = Enumerable.Range(0, 10);
            Parallel.ForEach(num, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ForEachSleeping");
            });
            Console.WriteLine("Elapsed: {0}MS", s.ElapsedMilliseconds);
            s.Stop();
            Console.Read();
        }
    }
}
