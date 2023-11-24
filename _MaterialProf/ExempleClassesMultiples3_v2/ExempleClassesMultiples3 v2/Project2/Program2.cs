using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project 2");
            MyClass3 b = new MyClass3();
            // Console.WriteLine(b.myF1());  // b inherits myF1() as a protected method, so not visible here
            Console.WriteLine(b.myF5());
            Console.WriteLine(b.myF6());  
            Console.ReadKey();
        }
    }
}
