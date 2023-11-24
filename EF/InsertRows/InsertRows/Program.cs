using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertRows
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();

        static void Main(string[] args)
        {

            try
            {
                db.COMPANY.Add(new COMPANY { ID = 1, NAME = "Paul", AGE = 32, ADDRESS = "California", SALARY = 20000 });
                db.COMPANY.Add(new COMPANY { ID = 2, NAME = "Allen", AGE = 25, ADDRESS = "Texas", SALARY = 15000 });
                db.COMPANY.Add(new COMPANY { ID = 3, NAME = "Teddy", AGE = 35, ADDRESS = "Norway", SALARY = 20000 });
                db.COMPANY.Add(new COMPANY { ID = 4, NAME = "Mark", AGE = 25, ADDRESS = "Richmond", SALARY = 65000 });
                db.SaveChanges();
                Console.WriteLine("Data successfully inserted");
            }
            catch (Exception)
            {
                Console.WriteLine("Tables not created");
            }


            Console.ReadKey();


        }
    }
}

