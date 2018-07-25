using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrenStackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);
            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);
            stack.PushRange(new int[] { 1, 2, 3, 4, 5 });
            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
