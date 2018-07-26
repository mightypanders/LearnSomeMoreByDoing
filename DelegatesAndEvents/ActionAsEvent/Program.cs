using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAsEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Method 1");
            p.OnChange += () => Console.WriteLine("Method 2");
            p.Raise();
            Console.ReadLine();

        }
    }
    public class Pub
    {
        public Action OnChange { get; set; }
        public void Raise()
        {
            OnChange?.Invoke();
        }
    }
}
