using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessMod;  //pour éviter d'écrire AccessMod.MyClass1.
                  // Pour que le projet ExempleAccessMod2 ait accès au projet ExempleAccessMod1, 
                  // il faut inclure une "référence". (add reference).

namespace AccessMod2
{
    public class MyClass3 : MyClass1
    {
        public void F3()
        {
            Console.WriteLine("À partir de la Class3");
            Console.WriteLine(" x1 n'est pas visible dans la Class3");
            Console.WriteLine(" x2 = " + x2);
            Console.WriteLine(" x3 n'est pas visible dans la Class3");
            Console.WriteLine(" x4 = " + x4);
            Console.WriteLine(" x5 = " + x5);
        }

    }
}
