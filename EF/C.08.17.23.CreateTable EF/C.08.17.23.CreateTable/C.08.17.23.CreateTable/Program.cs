using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C._08._17._23.CreateTable
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();

        static void Main(string[] args)
        {
            String cmdText = "CREATE TABLE COMPANY " +
                "(ID INT PRIMARY KEY NOT NULL, " +
                "NAME VARCHAR(50) NOT NULL, " +
                "AGE INT NOT NULL, " +
                "ADDRESS VARCHAR(100), " +
                "SALARY DECIMAL(9,2))";
            try
            {
                db.Database.ExecuteSqlCommand(cmdText, new object[0]);
                Console.WriteLine("Tables sucessfully created");
            }
            catch (Exception) 
            {
                Console.WriteLine("Tables not created");
            }


                Console.ReadKey();
        }
    }
}
