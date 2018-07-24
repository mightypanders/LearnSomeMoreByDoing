using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactories
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var res = new Int32[3];
                List<Task> tasks = new List<Task>();

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
                tasks.Add(tf.StartNew(() =>
                {
                    res[0] = 0;
                    Thread.Sleep(1000);
                    Console.WriteLine("added 0");
                }));
                tasks.Add(tf.StartNew(() =>
                {
                    res[1] = 1;
                    Thread.Sleep(1000);
                    Console.WriteLine("added 1");
                }));
                tasks.Add(tf.StartNew(() =>
                {
                    res[2] = 2;
                    Thread.Sleep(1000);
                    Console.WriteLine("added 2");
                }));
                Task.WaitAll(tasks.ToArray());
                return res;
            });
            var fTask = parent.ContinueWith(
                pt =>
                {
                    foreach (var item in pt.Result)
                    {
                        Console.WriteLine(item);
                    }
                });
            fTask.Wait();
            Console.Read();
        }

    }

}
