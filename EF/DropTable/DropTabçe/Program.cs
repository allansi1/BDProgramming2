using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropTabçe
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();
        static void Main(string[] args)
        {
            try
            {
                db.Database.ExecuteSqlCommand("DROP TABLE COMPANY", new object[0]);
                Console.WriteLine("Tables sucessfully deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Table not deleted");
            }
            Console.ReadKey();            
           
        }
    }
}
