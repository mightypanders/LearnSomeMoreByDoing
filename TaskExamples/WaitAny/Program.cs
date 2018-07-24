using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitAny
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task<int>.Run(() => { Thread.Sleep(1000); return 1; });
            tasks[1] = Task<int>.Run(() => { Thread.Sleep(3000); return 2; });
            tasks[2] = Task<int>.Run(() => { Thread.Sleep(2000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> comp = tasks[i];
                Console.WriteLine(comp.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
            Console.Read();
        }
    }
}
