using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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

                // =========================================================================
                // == Definition manuelle du schema et de la clé primaire
                //ds.Tables["COMPANY"].Columns["ID"].AllowDBNull = false;
                //ds.Tables["COMPANY"].Columns["ID"].Unique = true;
                //ds.Tables["COMPANY"].Columns["NAME"].AllowDBNull = false;
                //ds.Tables["COMPANY"].Columns["AGE"].AllowDBNull = false;
                //ds.Tables["COMPANY"].PrimaryKey = new DataColumn[1] { ds.Tables["COMPANY"].Columns["ID"] };
                // ============================================================================

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();

                init = true;
            }
            return ds.Tables["COMPANY"];
        }
        
        internal static void UpdateData()
        {
            adapter.Update(ds.Tables["COMPANY"]);
        }

        internal static void ReInitData()
        {
            //if (!init) { GetData(); }     // not needed: at this point init is always "true".  
            // This code (the next two lines) work with bindingSource, place the first cell as the selected one.
            //ds.Clear();
            //adapter.Fill(ds, "Company");
            // With bindingSource, it is better doing: 
            //     init = false;
            // and then, in the method bindingSource1_CurrentChanged() in the tier UI make: 
            //     bindingSource1.DataSource = EMPData.Company.GetData();
            // It works because bindingSource1.DataSource = EMPData.Company.GetData();
            // can be executed in the eventhandler CurrentChanged.
            init = false;
        }
    }
}
