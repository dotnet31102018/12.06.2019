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

        public AsyncPrint()
        {
            allMessages = new Queue<string>();
        }

        public void AddMessage(string msg)
        {
            lock(this)
            {
                allMessages.Enqueue(msg);
                Monitor.Pulse(this);
            }
        }

        public void CheckPrintMessage()
        {
            lock(this)
            {
                while (allMessages.Count == 0)
                {
                    Monitor.Wait(this);
                }
                Console.WriteLine(allMessages.Dequeue());
            }
        }
    }
}
