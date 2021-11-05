using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAsync
{
    static class TaskQueue
    {
        private static ConcurrentQueue<Context> queue = new ConcurrentQueue<Context>();

        public static Context next()
        {
            Context result;
            if (queue.TryDequeue(out result))
            {
                return result;
            }
            else
            {
                Thread.Sleep(1000);
                return null;
            }
        }

        public static void addTask(Context context)
        {
            queue.Enqueue(context);
        }
    }
}
