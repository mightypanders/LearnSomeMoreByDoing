using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Task t = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token);
            try
            {
                Console.WriteLine(" Enter to stop");
                Console.ReadLine();
                cts.Cancel();
                t.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
            Console.WriteLine("Enter to end");
            Console.ReadLine();
        }
    }
}
