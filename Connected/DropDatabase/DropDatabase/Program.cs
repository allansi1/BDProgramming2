using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            //cs.InitialCatalog = "master";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            SqlConnection con = new SqlConnection(cs.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "ALTER DATABASE EMP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" + 
                "DROP DATABASE EMP;";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database sucessfully deleted");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Database not deleted");
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
