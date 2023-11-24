using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteData
{
    internal class Program
    {
        static EMPEFEntities db = new EMPEFEntities();
        static void Main(string[] args)
        {
            foreach (var r in db.COMPANY)
            {
                db.COMPANY.Remove(r);
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Data sucessfull deleted");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not deleted");
            }
        }
    }
}
