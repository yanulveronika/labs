using System;
using System.Collections.Generic;
using System.Text;

namespace LB5
{
    class A
    {
        public int x = 1;
    }
    class B : A
    {
        public new int x = 2;
        public void m(int a, int b)
        {
            x = a;
            base.x = b;
            Console.Write(x + " " + base.x);
        }
    }
}

