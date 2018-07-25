using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            int res;
            bool stopped = false;
            ConcurrentQueue<int> q = new ConcurrentQueue<int>();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    q.Enqueue(i);
                    Console.Write("Enqueue: {0}", i);
                    Console.WriteLine("<  Queue Length: {0}", q.Count);
                    Thread.Sleep(1);
                }
            }).ContinueWith((i) => { stopped = true; Console.WriteLine("stopped"); });
            Task.Run(() =>
            {
                while (!stopped || q.Count > 0)
                {
                    if (q.TryDequeue(out res))
                        Console.Write("Dequeue: {0}", res);
                    Console.WriteLine(">  Queue Length: {0}", q.Count);
                    Thread.Sleep(1);
                }
            });
            Console.ReadKey();



        }
    }
}
