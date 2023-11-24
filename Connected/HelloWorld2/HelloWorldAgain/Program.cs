using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld2;

namespace HelloWorldAgain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Again");
            MyClass a = new MyClass();
            Console.WriteLine("a.x = " + a.x);
            Console.ReadKey();
        }
    }
}
