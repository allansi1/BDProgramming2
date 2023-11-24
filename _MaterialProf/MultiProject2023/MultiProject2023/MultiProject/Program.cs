using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space2;

namespace Space1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Space 1 - Program");

            MyClass a = new MyClass();

            Console.WriteLine("a.x = " + a.x);

            Console.ReadKey();
        }
    }
}
