using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDA
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "COMPANY");

            DataRow[] selectedRows;
            
            selectedRows = ds.Tables["COMPANY"].Select("ID=1");
            selectedRows[0]["SALARY"] = 25000.00;//Quer dizer selectedRows[0][4] = id e salary

            selectedRows = ds.Tables["COMPANY"].Select("ID=2");
            selectedRows[0].Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds.Tables["COMPANY"]);

            Console.WriteLine(ds.GetXml());
            Console.ReadKey();
        }
    }
}
