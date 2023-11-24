using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertRowsDA
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
            adapter.Fill(ds, "COMPANY-M");

            DataRow row = ds.Tables["COMPANY-M"].NewRow();
            row["ID"] = 2;
            row["NAME"] = "Allen";
            row["AGE"] = 25;
            row["ADDRESS"] = "Texas";
            row["SALARY"] = 15000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();
            row[0] = 1;
            row[1] = "Paul";
            row[2] = 32;
            row[3] = "California";
            row[4] = 20000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();
            row[0] = 3;
            row[1] = "Paul";
            row[2] = 32;
            row[3] = "Paris";
            row[4] = 20000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();
            row[0] = 4;
            row[1] = "Mark";
            row[2] = 25;
            row[3] = "Richmond";
            row[4] = 65000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds.Tables["COMPANY-M"]);

            Console.WriteLine(ds.GetXml());
            Console.ReadKey();

        }
    }
}
