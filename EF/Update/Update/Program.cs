using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();
        static void Main(string[] args)
        {
            var result = db.COMPANY.Where(s => s.ID == 1).SingleOrDefault();
            if(result!= null)
            {
                result.SALARY = (decimal)25000.00;
            }
            var result2 = db.COMPANY.Where(s => s.ID == 2).SingleOrDefault();
            if(result2!= null)
            {
                db.COMPANY.Remove(result2);
            }
            else
            {
                Console.WriteLine("Employee not found for removal");
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Data sucessfull updated");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not update");
            }

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
