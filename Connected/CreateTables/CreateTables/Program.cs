using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CreateTables
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

            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CREATE TABLE COMPANY" + 
               "(ID INT PRIMARY KEY NOT NULL," +
               "NAME TEXT NOT NULL," +
               "AGE INT NOT NULL," +
               "ADDRESS CHAR(50)," +
               "SALARY REAL)";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tables sucessfully created");
               
            }
            catch (Exception e) {
                Console.WriteLine("Tables not created");            
            }

            con.Close();
            Console.ReadKey();

        }
    }
}
