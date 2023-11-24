using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();
        static void Main(string[] args)
        {
            foreach (var c in db.COMPANY)
            {
                Console.WriteLine("Id = {0}; Name = {1}", c.ID, c.NAME);
                Console.WriteLine("Age = {0}", c.AGE);
                Console.WriteLine("Address = {0}", c.ADDRESS);
                Console.WriteLine("Salary = {0:F2}", c.SALARY);
                Console.WriteLine("Salary = {0}", c.SALARY.Value.ToString("F2"));
                Console.WriteLine("Salary = {0}", c.SALARY.Value.ToString("N2"));
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
