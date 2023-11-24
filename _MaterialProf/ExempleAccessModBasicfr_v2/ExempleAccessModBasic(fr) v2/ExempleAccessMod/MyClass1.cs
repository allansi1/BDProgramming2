using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMod
{
    public class MyClass1
    {
        private int x1 = 1;               // visible in MyClass1 seulement

        protected int x2 =2;              // visible in MyClass1, MyClass2 and MyClass3

        internal int x3 =3;               // visible in MyClass1, MyClass2 and Program1 

        internal protected int x4 = 4;    // visible in MyClass1, MyClass2, Program1 and MyClass3 (but not in Program2) 

        public int x5 = 5;                // visible in MyClass1, MyClass2, Program1, MyClass3 and Program2 

        public void F1()
        {
            Console.WriteLine("À partir de la Class1");
            Console.WriteLine(" x1 = " + x1);
            Console.WriteLine(" x2 = " + x2);
            Console.WriteLine(" x3 = " + x3);
            Console.WriteLine(" x4 = " + x4);
            Console.WriteLine(" x5 = " + x5);
        }

        //-------------------------------------------------------------------
        // From MyClass1: 
        // public -  visible in MyClass1, MyClass2, Program1, MyClass3 and Program2  
        // internal protected - visible in MyClass1, MyClass2, Program1 and MyClass3 (but not in Program2)
        // internal - visible in MyClass1, MyClass2 and Program1 
        // protected - visible in MyClass1, MyClass2 and MyClass3
        // protected private -  visible in MyClass1 and MyClass2     // Disponible à partir de C# 7.2
        // private - visible in MyClass1 
        //-------------------------------------------------------------------
    }
}
