using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] baselist = new int[] { 12, 35, 10, 250, 12, 77, 35, 7, 9, 10};

            //Syntax Method 1 - > 30
            var syntaxMethod1 = baselist.Where(s => s> 30)
                                              .OrderBy(s => s)
                                              .Select(s => new { s });
            Console.WriteLine("Syntax Method: Number > 30");

            foreach (var item in syntaxMethod1)
            {
                Console.WriteLine("Number: " + item);
            }
            Console.WriteLine();


            // LINQ Query Syntax  - > 30
            var query = from s in baselist
                                   where s > 30
                                   orderby s
                                   select new { s };
            Console.WriteLine("Query syntax: Number > 30");

            foreach (var item in query)
            {
                Console.WriteLine("Number: " + item);
            }
            Console.WriteLine();

            //Syntax Method 2 - sans repetion

            Console.WriteLine("Method syntax: Distinct numbers");

            var syntaxMethod2 = baselist.Distinct();

            foreach (var item in syntaxMethod2)
            {
                Console.WriteLine("Number: " + item);
            }
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
