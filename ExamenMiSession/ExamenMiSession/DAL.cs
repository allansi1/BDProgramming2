using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Connect
    {
        private static String cliComConnectionString = GetConnectString();
        internal static String ConnectionString { get => cliComConnectionString; }

        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "examen1IG";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;

        }
    }

    internal class DataTables
    {
        private static SqlDataAdapter adapterDept = InitAdapterDept();
        private static SqlDataAdapter adapterEmp = InitAdapterEmp();
        private static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterDept()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM departments ORDER BY DeptId", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;
        }

        private static SqlDataAdapter InitAdapterEmp()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM employees ORDER BY EmpId", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;
        }

        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            loadTables(ds);
            return ds;
        }

        private static void loadTables(DataSet ds)
        {
            adapterDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterDept.Fill(ds, "Departments");

            adapterEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterEmp.Fill(ds, "Employees");

            //Foreign Key
            ForeignKeyConstraint myFK1 = new ForeignKeyConstraint("MyFK1",
                new DataColumn[] {
                ds.Tables["Employees"].Columns["EmpId"],
                },
                new DataColumn[]
                {
                   ds.Tables["Departments"].Columns["MgrId"],
                   
                }
            );
            myFK1.DeleteRule = Rule.None;
            myFK1.UpdateRule = Rule.None;
            ds.Tables["Departments"].Constraints.Add(myFK1);
       
           
            //Foreign Key
            ForeignKeyConstraint myFK2 = new ForeignKeyConstraint("MyFK2",
                new DataColumn[] {

                    ds.Tables["Departments"].Columns["DeptId"],
                    
                },
                new DataColumn[]
                {
                    ds.Tables["Employees"].Columns["DeptId"],
                }
            );
            myFK2.DeleteRule = Rule.None;
            myFK2.UpdateRule = Rule.Cascade;
            ds.Tables["Employees"].Constraints.Add(myFK2);


        }

        internal static SqlDataAdapter GetAdapterDept()
        {
            return adapterDept;
        }

        internal static SqlDataAdapter GetAdapterEmp()
        {
            return adapterEmp;
        }

        internal static DataSet GetDataSet()
        {
            return ds;
        }

    }

    internal class Department
    {
        private static SqlDataAdapter adapterDept = DataTables.GetAdapterDept();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetDept()
        {
            return ds.Tables["Departments"];
        }

        internal static int UpdateDept()
        {
            if (!ds.Tables["Departments"].HasErrors)
            {
                return adapterDept.Update(ds.Tables["Departments"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Employe
    {
        private static SqlDataAdapter adapterEmp = DataTables.GetAdapterEmp();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetEmp()
        {
            return ds.Tables["Employees"];
        }

        internal static int UpdateEmp()
        {
            if (!ds.Tables["Employees"].HasErrors)
            {
                return adapterEmp.Update(ds.Tables["Employees"]);
            }
            else
            {
                return -1;
            }
        }
    }

}
