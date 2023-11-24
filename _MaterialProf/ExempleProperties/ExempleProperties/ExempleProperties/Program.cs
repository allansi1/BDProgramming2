using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplesProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 v = new MyClass1();

            v.A1 = -150;
            v.A2 = -250;
            v.A3 = -350;
            v.A5 = -450;
            Console.WriteLine(v.A1);
            Console.WriteLine(v.A2);
            Console.WriteLine(v.A3);
            Console.WriteLine(v.A4);
            Console.WriteLine(v.A5);
            Console.WriteLine(v.A6);

            Console.WriteLine(v.R1);
            Console.WriteLine(v.R2);
            Console.WriteLine(v.R3);
            Console.WriteLine(v.R4);
            Console.WriteLine(v.R5);

            MyClass2 v2 = new MyClass2();

            v2.Hours = 2;
            Console.WriteLine(v2.Seconds);
            Console.WriteLine(v2.Minutes);

            Console.ReadKey();

        }
    }
}
