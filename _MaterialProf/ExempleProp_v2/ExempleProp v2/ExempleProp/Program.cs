using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleProp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass();

            a.X2 = 5;
            Console.WriteLine("a.X2 = " + a.X2);

            Console.WriteLine("a.X3 = "+a.X3);
            // a.X3 = 20;  // pas possible parce que le mutateur est privé.

            // X6 et X7 font référence au même attribut (privé) x6. 
            // les mutateurs de X6 et de X7 traitent les valeurs négatives de façon différente. 

            Console.WriteLine("On fait  a.X6 = 1 ");
            a.X6 = 1;
            Console.WriteLine("a.X6 = " + a.X6);
            Console.WriteLine("a.X7 = " + a.X7);

            Console.WriteLine("On fait  a.X7 = 2 ");
            a.X7 = 2;
            Console.WriteLine("a.X6 = " + a.X6);
            Console.WriteLine("a.X7 = " + a.X7);

            Console.WriteLine("On fait  a.X6 = -1 ");
            a.X6 = -1;
            Console.WriteLine("a.X6 = " + a.X6);
            Console.WriteLine("a.X7 = " + a.X7);

            Console.WriteLine("On fait  a.X7 = -2 ");
            a.X7 = -2;
            Console.WriteLine("a.X6 = " + a.X6);
            Console.WriteLine("a.X7 = " + a.X7);

            Console.WriteLine("a.X9 = " + a.X9);
            // a.X9 = 200;  // pas possible parce que le mutateur est privé.

            Console.ReadKey();
        }
    }
}
