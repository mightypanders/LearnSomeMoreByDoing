using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateExceptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Enumerable.Range(0, 40);
            try
            {
                var res = num.AsParallel().Where(i => isEven(i));
                res.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("{0} inner Exceptions", e.InnerExceptions.Count);
                if (e.InnerExceptions.Count > 0)
                {
                    foreach (var item in e.InnerExceptions)
                    {
                        Console.WriteLine(item.Message);
                    }
                }
            }
            finally
            {
                Console.Read();
            }
        }

        private static bool isEven(int i)
        {
            try
            {
                if (i % 10 == 0) throw new ArgumentException(String.Format("i: {0}", i));
            }
            catch (ArgumentException)
            {
                throw;
            }
            return i % 2 == 0;
        }
    }
}
