using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1206_
{
    public class AsyncPrint
    {
        private Queue<string> allMessages;

        private const int THREADS_COUNTER = 10;

        public AsyncPrint()
        {
            allMessages = new Queue<string>();
            for (int i = 0; i < THREADS_COUNTER; i++)
            {
                new Thread(() => { CheckPrintMessage(); }).Start();
            }
        }

        public void AddMessage(string msg)
        {
            lock(this)
            {
                allMessages.Enqueue(msg);
                Monitor.PulseAll(this);
            }
        }

        public void CheckPrintMessage()
        {
            lock(this)
            {
                while (true)
                {
                    if (allMessages.Count > 0)
                    {
                        Console.WriteLine(allMessages.Dequeue());                        
                    }
                    Monitor.Wait(this);
                }
            }
        }
    }
}
