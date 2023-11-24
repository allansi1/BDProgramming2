using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ01
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

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Func<string, bool> containsTut = s => s.Contains("Tutorials");
     
            // LINQ Query Syntax
            var result2 = from s in stringList
                         where containsTut(s)
                          select s;

            foreach (var str in result2)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
