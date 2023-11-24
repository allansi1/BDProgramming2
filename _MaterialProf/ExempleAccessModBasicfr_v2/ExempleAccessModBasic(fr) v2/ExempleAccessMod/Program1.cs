using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccessMod
{
    class Program1
    {
       
        static void Main(string[] args)
        {
            MyClass1 a = new MyClass1();
            Console.WriteLine("À partir de la Class Program1");
            Console.WriteLine(" a.x1 n'est pas visible dans le Program1");
            Console.WriteLine(" a.x2 n'est pas visible dans le Program1");
            Console.WriteLine(" a.x3 = "+ a.x3);
            Console.WriteLine(" a.x4 = " + a.x4);
            Console.WriteLine(" a.x5 = " + a.x5);

            a.F1();

            MyClass2 b = new MyClass2();
            b.F2();

            /* 
             * Le projet ExempleAccessMod2 fait déjà référence au projet ExempleAccessMod1.
             * Alors, le projet ExempleAccessMod1 ne peut pas faire référence au projet ExempleAccessMod2.
             * Cela serait une référence circulaire.
             * Alors, Program1 ne peut pas acceder à MyClass3
             */
            // MyClass3 c = new MyClass3();  
            // c.F3();

            Console.ReadKey();

        }
    }
}
