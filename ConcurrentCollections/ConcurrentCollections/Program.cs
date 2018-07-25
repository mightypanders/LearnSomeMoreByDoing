using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (var item in col.GetConsumingEnumerable())
                    Console.WriteLine(item);
            });
            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        col.CompleteAdding();
                        break;

                    }
                    col.Add(s);
                }
            });
            write.Wait();
            Task secondWrite = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s))
                        break;
                    col.Add(s);
                }
            });
            secondWrite.Wait();
        }
    }
}
