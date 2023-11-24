using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CreateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            //cs.InitialCatalog = "master";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            Console.WriteLine(cs.ConnectionString);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;
            //SqlConnection con = new SqlConnection(cs.ConnectionString); // another way of setting the connection
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CREATE DATABASE EMP";
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database successfully created");
            }
            catch (Exception e)
            {
                Console.WriteLine("Database not created");
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
