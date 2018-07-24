using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParameteredThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread Working");
                Thread.Sleep(1);
            }
            t.Join();
            Console.Read();
        }
        public static void ThreadMethod(object o)
        {

            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1);
            }
        }
    }
}
