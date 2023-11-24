using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeleteAllData
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
            cmd.CommandText = "DELETE FROM COMPANY";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Datas deleted");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Data not deleted");
            }
            con.Close();
            Console.ReadKey();


        }
    }
}
