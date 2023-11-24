using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project 1");
            MyClass1 a = new MyClass1();
            // Console.WriteLine(a.myF1());  // myF1() is not visible here
            Console.WriteLine(a.myF2());

            MyClass2 c = new MyClass2();
            Console.WriteLine(c.myF3());
            Console.WriteLine(c.myF4());

            Console.ReadKey();
        }
    }
}
