using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Enumerable.Range(0, 100);
            var res = num.AsParallel().AsOrdered().Where(i => i % 2 == 0);
            res.ForAll(e => Console.WriteLine(e));
        }
    }
}
