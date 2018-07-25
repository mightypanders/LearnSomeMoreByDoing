using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwaitExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadKey();
            var result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static async Task<string> DownloadContent()
        {
            using (HttpClient c = new HttpClient())
            {
                var res = await c.GetStringAsync("http://www.microsoft.com");
                return res;
            }
        }
    }
}
