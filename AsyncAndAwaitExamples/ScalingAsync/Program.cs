using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScalingAsync
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static Task SleepA(int mil)
        {
            return Task.Run(() => Thread.Sleep(mil));
        }

        static Task SleepB(int mil)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(mil, -1);
            return tcs.Task;
        }
    }
}
