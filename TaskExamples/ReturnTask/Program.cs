using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReturnTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return 42;
            });
            Console.WriteLine(t.Result);
            Console.Read();
        }
    }
}
