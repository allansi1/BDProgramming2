using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPData
{
    internal class Company
    {
        static SqlDataAdapter adapter;
        static DataSet ds;
        static bool init = false;

        internal static DataTable GetData()
        {
            if (!init)
            {
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "(local)";
                cs.InitialCatalog = "EMP";
                cs.UserID = "sa";
                cs.Password = "sysadm";
                adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                ds = new DataSet();
                adapter.Fill(ds, "COMPANY");

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                init = true;
            }
            return ds.Tables["COMPANY"];
        }

        internal static void InsertData(Employee emp)
        {
            if (EMPBusiness.Operation.IsValid(emp))
            {
                DataRow line = ds.Tables["COMPANY"].NewRow();

                try
                {

                    line.SetField("ID", emp.Id);
                    line.SetField("NAME", emp.Name);
                    line.SetField("AGE", emp.Age);
                    line.SetField("ADDRESS", emp.Address);
                    line.SetField("SALARY", emp.Salary);
                    ds.Tables["COMPANY"].Rows.Add(line);

                    adapter.Update(ds.Tables["COMPANY"]);
                }
                catch (SqlException) 
                {
                    Query1aPlus.Form1.UIMessage("Database: Insertion rejected");
                }
                catch (Exception)
                {
                    Query1aPlus.Form1.UIMessage("Data Layer: Insetion rejected");
                }
            }
        }

        internal static void UpdateData(Employee emp)
        {
            if (EMPBusiness.Operation.IsValid(emp))
            {
                try
                {
                    var line = ds.Tables["COMPANY"].AsEnumerable()
                        .Where(s=> s.Field<int>("ID")==emp.Id).SingleOrDefault();
                    if (line != null)
                    {
                        line.SetField("NAME", emp.Name);
                        line.SetField("AGE", emp.Age);
                        line.SetField("ADDRESS", emp.Address);
                        line.SetField("SALARY", emp.Salary);

                        adapter.Update(ds.Tables["COMPANY"]);
                    }
                }
                catch (SqlException)
                {
                    Query1aPlus.Form1.UIMessage("Database: Update rejected");
                }
                catch (Exception)
                {
                    Query1aPlus.Form1.UIMessage("Data Layer: Update rejected");
                }
            }
        }

        internal static void DeleteData(List<int> lId)
        {
            try
            {
                var lines = ds.Tables["COMPANY"].AsEnumerable()
                    .Where(s => lId.Contains(s.Field<int>("ID")));
                foreach (var line in lines)
                {
                    line.Delete();
                }
                adapter.Update(ds.Tables["COMPANY"]);
            }
            catch (SqlException)
            {
                Query1aPlus.Form1.UIMessage("Database: Delete rejected");
            }
            catch (Exception)
            {
                Query1aPlus.Form1.UIMessage("Data Layer: Delete rejected");
            }
        }


    }

    internal class Employee
    {
        public int Id;
        public string Name;
        public int Age;
        public string Address;
        public decimal Salary;
        
    }
}
