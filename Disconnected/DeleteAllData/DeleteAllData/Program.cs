using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "COMPANY");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr.Delete();
            }

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds.Tables["COMPANY"]);

            Console.WriteLine(ds.GetXml());
            Console.ReadKey();
            
        }
    }
}
