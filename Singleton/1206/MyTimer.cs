using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1206
{
    public class MyTimer
    {
        // alternative solution for lock - by creating a single instance in the static readonly field
        //private static readonly MyTimer INSTANCE = new MyTimer();

        private static MyTimer INSTANCE;
        private static Object key = new object();
        protected MyTimer()
        {

        }

        public string GetTime()
        {
            return $"Time in Israel: {DateTime.Now}";
        }

        public static MyTimer GetInstance()
        {
            if (INSTANCE == null)
            {
                lock (key)
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new MyTimer();
                    }
                }
            }
            return INSTANCE;
        }


    }
}
