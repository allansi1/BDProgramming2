using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPaire
{
    internal class Program
    {
        static void Main(string[] args)
        {

           Paire<int> a = new Paire<int>(2,3);
            Console.WriteLine("a = " + a);
            

            Paire<int> b = a.Transpose1();
            Console.WriteLine("b = " + b);

            a.Transpose2();
            Console.WriteLine("a = " + a);

            Paire<String> c = new Paire<String>("Bonjour", "Bonsoir");
            Console.WriteLine("c = " + c);

            Paire<String> d = c.Transpose1();
            Console.WriteLine("d = " + d);
            c.Transpose2();
            Console.WriteLine("c = " + c);
           
            Console.ReadKey();

        }
    }
}
