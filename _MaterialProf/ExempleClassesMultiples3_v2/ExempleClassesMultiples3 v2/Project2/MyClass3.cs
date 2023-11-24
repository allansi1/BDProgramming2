using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project1;  // to access MyClass1 we need this using statement AND to "add reference".

namespace Project2
{
    class MyClass3 : MyClass1
    {
        internal string myF5()
        {
            return "I'm myF5() from MyClass3 and myF1() returns: " + this.myF1();
        }

        internal string myF6()
        {
            return "I'm myF6() from MyClass3 and myF2() is not visible from MyClass3"; // this.myF2();
        }
    }
}
