using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            ParallelLoopResult res = Parallel.For(0, 1000, (int i, ParallelLoopState state) =>
            {
                Console.WriteLine(i);
                if (i >= 500)
                {
                    Console.WriteLine("Breaking Loop");
                    state.Break();
                }
                return;
            });
            Console.WriteLine("loop broken at {0}", res.LowestBreakIteration);
            Console.Read();
        }
    }
}
