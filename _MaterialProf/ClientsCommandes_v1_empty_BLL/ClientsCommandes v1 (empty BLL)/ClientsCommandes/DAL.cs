using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    internal class Connect
    {
        // =========================================================================
        // We could use the Design Pattern Singleton for this class. 
        // However, it is also possible (and a little simpler) to 
        // just use static attributes and static methods.
        // =========================================================================

        private static String cliComConnectionString = GetConnectString();

        internal static String ConnectionString { get => cliComConnectionString; }

        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "ClientsCommandes";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }
    }

    internal class DataTables
    {
        // =========================================================================
        // We could use the Design Pattern Singleton for this class. 
        // However, it is also possible (and a little simpler) to 
        // just use static attributes and static methods.
        // =========================================================================

        private static SqlDataAdapter adapterClients = InitAdapterClients();
        private static SqlDataAdapter adapterCommandes = InitAdapterCommandes();

        private static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterClients()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM clients ORDER BY ClientId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterCommandes()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM commandes ORDER BY ComId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            // For the ON UPDATE CASCADE relative to ClientId
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            //
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            loadClients(ds);
            loadCommandes(ds);
            return ds;
        }

        private static void loadClients(DataSet ds)
        {
            // =========================================================================
            adapterClients.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // =========================================================================

            adapterClients.Fill(ds, "Clients");

            // =========================================================================
            //ds.Tables["Clients"].Columns["ClientId"].AllowDBNull = false;
            //ds.Tables["Clients"].Columns["Nom"].AllowDBNull = false;

            //ds.Tables["Clients"].PrimaryKey = new DataColumn[1]
            //        { ds.Tables["clients"].Columns["ClientId"]};
            // =========================================================================
        }

        private static void loadCommandes(DataSet ds)
        {
            // =========================================================================
            adapterCommandes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // =========================================================================

            adapterCommandes.Fill(ds, "Commandes");

            //ds.Tables["Commandes"].Columns["ComId"].AllowDBNull = false;
            //ds.Tables["Commandes"].Columns["Description"].AllowDBNull = false;
            //ds.Tables["Commandes"].Columns["Prix"].AllowDBNull = false;
            //ds.Tables["Commandes"].Columns["ClientId"].AllowDBNull = false;

            //ds.Tables["Commandes"].PrimaryKey = new DataColumn[1]
            //        { ds.Tables["Commandes"].Columns["ComId"]};

            // =========================================================================  
            /* Foreign Key between DataTables */

            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
                new DataColumn[]{
                    ds.Tables["Clients"].Columns["ClientId"]
                },
                new DataColumn[] {
                    ds.Tables["Commandes"].Columns["ClientId"],
                }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.Cascade;
            ds.Tables["Commandes"].Constraints.Add(myFK);

            // =========================================================================  
        }

        internal static SqlDataAdapter getAdapterClients()
        {
            return adapterClients;
        }
        internal static SqlDataAdapter getAdapterCommandes()
        {
            return adapterCommandes;
        }
        internal static DataSet getDataSet()
        {
            return ds;
        }
    }

    internal class Clients
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterClients();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetClients()
        {
            return ds.Tables["Clients"];
        }

        internal static int UpdateClients()
        {
            if (!ds.Tables["Clients"].HasErrors)
            {
                return adapter.Update(ds.Tables["Clients"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Commandes
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCommandes();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetCommandes()
        {
            return ds.Tables["Commandes"];
        }

        internal static int UpdateCommandes()
        {
            if (!ds.Tables["Commandes"].HasErrors)
            {
                return adapter.Update(ds.Tables["Commandes"]);
            }
            else
            {
                return -1;
            }
        }
    }
}
