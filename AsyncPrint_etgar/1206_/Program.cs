using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1206_
{
    class Program
    {
        interface I1
        {
            void foo();
        }
        class A : I1
            {
            public void foo()
            {
                throw new NotImplementedException();
            }
        }
        class B : A, I1
        {

        }
        static void Main(string[] args)
        {

        }
    }
}
