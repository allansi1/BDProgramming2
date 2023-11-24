using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InsertRowsDA
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
            adapter.Fill(ds, "COMPANY-M");

            DataRow row = ds.Tables["COMPANY-M"].NewRow();   //  Create a new DataRow
            row["ID"] = 2;
            row["NAME"] = "Allen";
            row["AGE"] = 25;
            row["ADDRESS"] = "Texas";
            row["SALARY"] = 15000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();                   //  Create a new DataRow
            row[0] = 1;
            row[1] = "Paul";
            row["AGE"] = 32;
            row["ADDRESS"] = "California";
            row["SALARY"] = 20000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();           //  Create a new DataRow
            row["ID"] = 3;
            row["NAME"] = "Teddy";
            row["AGE"] = 23;
            row["ADDRESS"] = "Norway";
            row["SALARY"] = 20000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            row = ds.Tables["COMPANY-M"].NewRow();           //  Create a new DataRow
            row["ID"] = 4;
            row["NAME"] = "Mark";
            row["AGE"] = 25;
            row["ADDRESS"] = "Richmond";
            row["SALARY"] = 65000.00;
            ds.Tables["COMPANY-M"].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds.Tables["COMPANY-M"]);

            Console.WriteLine(ds.GetXml());
            Console.ReadKey();
        }
    }
}
