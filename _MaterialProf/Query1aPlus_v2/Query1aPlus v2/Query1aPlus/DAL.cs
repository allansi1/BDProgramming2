using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EMPData
{
    class Company
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

                // =========================================================================
                // === Pour que l'adapter fasse la definition de clé primaire de la DataTable 
                // === automatiquement, mais cela ne marche pas pour des clés étrangères
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                // ==========================================================================

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
                    Query1aPlus.Form1.UIMessage("Data Layer: Insertion rejected");
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
                                 .Where(s => s.Field<int>("ID") == emp.Id).SingleOrDefault();
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
                Query1aPlus.Form1.UIMessage("Database: Deletion rejected");
            }
            catch (Exception)
            {
                Query1aPlus.Form1.UIMessage("Data Layer: Deletion rejected");
            }
        }
    }

    internal class Employee
    {
        // Just a structure to represent a line in COMPANY table
        public int Id;
        public string Name;
        public int Age;
        public string Address;
        public decimal Salary;
    }
}
