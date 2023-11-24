using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            SqlConnection con = new SqlConnection(cs.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DROP TABLE COMPANY";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table deleted");
                Console.WriteLine();
            }
            catch (Exception) {
                Console.WriteLine("Table not deleted");
                Console.WriteLine();
            }
            con.Close();
            Console.ReadKey();
           
        }
    }
}
