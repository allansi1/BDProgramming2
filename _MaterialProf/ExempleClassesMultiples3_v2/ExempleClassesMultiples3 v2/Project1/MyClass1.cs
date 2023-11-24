using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class MyClass1
    {
        protected string myF1()
        {
            return "I am myF1() (an protected method of Class1)";
        }

        internal string myF2()
        {
            return "I am myF2() (an internal method of Class1)";
        }

        // ---------------------------------------------------------------------------------
        // From MyClass1: 
        // public -  visible in MyClass1, MyClass2, Program1, MyClass3 and Program2  
        // protected internal - visible in MyClass1, MyClass2, Program1 and MyClass3 (but not in Program2)
        // internal - visible in MyClass1, MyClass2 and Program1 
        // protected -  visible in MyClass1, MyClass2 and MyClass3
        // protected private -  visible in MyClass1 and MyClass2     // Disponible à partir de C# 7.2
        // private - visible in MyClass1
        // ---------------------------------------------------------------------------------
    }
}
