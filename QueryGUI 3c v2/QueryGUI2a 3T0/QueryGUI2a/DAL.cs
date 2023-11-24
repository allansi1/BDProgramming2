using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPData

{
    class Company
    {
        //DAL = Data Access Layer = camada de dados
        static SqlDataAdapter adapter;
        static DataSet ds;
        static bool init = false;

        internal static DataTable GetData()
        {
            if(!init)
            {

                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "(local)";
                cs.InitialCatalog = "EMP";
                cs.UserID = "sa";
                cs.Password = "sysadm";

                adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);

                //Pour que l'adapteur fasse la definition de clé primaire de la DataTable
                //automatiquemente, mas cela ne marche pas pour les clés étrangères
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                ds = new DataSet();
                adapter.Fill(ds, "COMPANY");

                SqlCommandBuilder buider = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = buider.GetUpdateCommand();
                init = true;
            }
            return ds.Tables["COMPANY"];
        }
        internal static void UpdateData()
        {
            adapter.Update(ds.Tables["COMPANY"]);
        }

    }
}
