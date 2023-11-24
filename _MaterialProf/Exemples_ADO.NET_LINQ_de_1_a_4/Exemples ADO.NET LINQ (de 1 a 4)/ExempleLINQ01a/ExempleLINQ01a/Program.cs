using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ01a
{
    class Program
    {
        static void Main(string[] args)
        {
            // string collection
            List<string> stringList = new List<string>() {
            "C# Tutorials",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials" ,
            "Java"
        };

            // LINQ Method Syntax
            var result = stringList.Where(s => s.Contains("Tutorials"));


            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Func<string, bool> containsTut = s => s.Contains("Tutorials");

            // LINQ Method Syntax
            var result2 = stringList.Where(containsTut);


            foreach (var str in result2)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
