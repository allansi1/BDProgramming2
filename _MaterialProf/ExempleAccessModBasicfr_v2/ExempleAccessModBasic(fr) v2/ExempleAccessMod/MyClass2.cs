using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMod
{
    public class MyClass2 : MyClass1  
    {
        public void F2()
        {
            Console.WriteLine("À partir de la Class2");
            Console.WriteLine(" x1 n'est pas visible dans la Class2");
            Console.WriteLine(" x2 = "+ x2);
            Console.WriteLine(" x3 = " + x3);
            Console.WriteLine(" x4 = " + x4);
            Console.WriteLine(" x5 = " + x5);
        }
    }
}
