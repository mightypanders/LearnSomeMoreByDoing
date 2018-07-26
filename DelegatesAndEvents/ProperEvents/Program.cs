using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProperEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub(42);

            p.OnChange += (sender, e) => PubChanged(sender, e);
            p.OnChange += (sender, e) =>
            {
                throw new Exception("Example Exception");
            };
            p.OnChange += (sender, e) => Console.WriteLine("this will only be seen using manual aggregate exception handling.");
            Console.ReadLine();
        }
        private static void PubChanged(object sender, MyArgs e)
        {
            Console.WriteLine("Event raised: {0}", e.Value);
        }
    }
    public class Pub
    {
        private int arg = 0;
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                    onChange += value;
            }
            remove
            {
                lock (onChange)
                    onChange -= value;
            }
        }
        public Pub(int _arg)
        {
            arg = _arg;
            Task.Run(() =>
            {
                SleepAndRaise(4000, 1);
            });
            Task.Run(() =>
            {
                SleepAndRaise(4100,2);
            });
            Task.Run(() =>
            {
                SleepAndRaise(4444, 3);
            });
        }
        private void SleepAndRaise(int _sleep, int _fac = 1)
        {
            try
            {
                Thread.Sleep(_sleep);
                Raise(_fac);

            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Exceptions: {0}", ex.InnerExceptions.Count);
                if (ex.InnerExceptions.Count > 0)
                {
                    foreach (var item in ex.InnerExceptions)
                    {
                        Console.WriteLine("     " + item.Message + " from Thread: " + Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }
        }
        public void Raise(int fac = 1)
        {
            var exceptions = new List<Exception>();
            foreach (var item in onChange.GetInvocationList())
            {
                try
                {
                    item.DynamicInvoke(this, new MyArgs(fac * arg));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
                throw new AggregateException(exceptions);

            //onChange(this, new MyArgs(fac * arg));
        }
    }
    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }
}
