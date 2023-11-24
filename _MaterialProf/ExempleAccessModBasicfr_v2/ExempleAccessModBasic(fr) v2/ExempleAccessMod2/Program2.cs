using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessMod;  // Pour éviter d'écrire AccessMod.MyClass1, AccessMod.MyClass2, etc...
                  // Pour que le projet ExempleAccessMod2 ait accès au projet ExempleAccessMod1, 
                  // il faut inclure une "référence". (add reference).

namespace AccessMod2
{
    class Program2
    {
        static void Main(string[] args)
        {

            MyClass1 a = new MyClass1();
            Console.WriteLine("À partir de la Class Program2");
            Console.WriteLine(" a.x1 n'est pas visible dans le Program2");
            Console.WriteLine(" a.x2 n'est pas visible dans le Program2");
            Console.WriteLine(" a.x3  n'est pas visible dans le Program2");
            Console.WriteLine(" a.x4  n'est pas visible dans le Program2");
            Console.WriteLine(" a.x5 = " + a.x5);

            a.F1();

            MyClass2 b = new MyClass2();
            b.F2();

            MyClass3 c = new MyClass3();  
            c.F3();

            Console.ReadKey();

        }
    }
}
