using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QueryDA2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "COMPANY");
            foreach (DataRow dr in ds.Tables["COMPANY"].Rows)
            {
                Console.WriteLine("Id = {0}; Name = {1}", dr["ID"], dr["NAME"]);
                Console.WriteLine("Age = {0}", dr["AGE"]);
                Console.WriteLine("Address = {0}", dr["ADDRESS"]);
                Console.WriteLine("Salary = {0:F2}", dr["SALARY"]);
                //Console.WriteLine("Salary = {0}", dr[4].ToString("F2"));  
                //Console.WriteLine("Salary = {0}", dr[4].ToString("N2"));
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
