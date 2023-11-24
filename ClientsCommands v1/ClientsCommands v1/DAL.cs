using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
            cs.InitialCatalog = "ClientsCommandes";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;

        }
    }

    internal class DataTables
    {
        private static SqlDataAdapter adapterClients = InitAdapterClients();
        private static SqlDataAdapter adapterCommandes = InitAdapterCommandes();
        private static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterClients()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM clients ORDER BY ClientId", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;
        }

        private static SqlDataAdapter InitAdapterCommandes()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM commandes ORDER BY ComId", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
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
            adapterClients.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterClients.Fill(ds, "Clients");
        }

        private static void loadCommandes(DataSet ds)
        {
            adapterCommandes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterCommandes.Fill(ds, "Commandes");
            //Foreign Key
            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
                new DataColumn[] {
                ds.Tables["Clients"].Columns["ClientId"]
                },
                new DataColumn[]
                {
                    ds.Tables["Commandes"].Columns["ClientID"],
                }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.Cascade;
            ds.Tables["Commandes"].Constraints.Add(myFK);

        }

        internal static SqlDataAdapter getAdapterClients()
        {
            return adapterClients;
        }

        internal static SqlDataAdapter getAdapterCommandes()
        {
            return adapterCommandes;
        }

        internal static DataSet GetDataSet()
        {
            return ds;
        }

    }

    internal class Clients
    {

        private static SqlDataAdapter adapterClient = DataTables.getAdapterClients();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetClients()
        {
            return ds.Tables["Clients"];
        }

        internal static int UpdateClients()
        {
            if (!ds.Tables["Clients"].HasErrors)
            {
                return adapterClient.Update(ds.Tables["Clients"]);
            }
            else
            {
                return -1;
            }
        }

    }

    internal class Commandes
    {
        private static SqlDataAdapter adapterCommande = DataTables.getAdapterCommandes();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetCommandes()
        {
            return ds.Tables["Commandes"];
        }
        internal static int UpdateCommandes()
        {
            if (!ds.Tables["Commandes"].HasErrors)
            {
                return adapterCommande.Update(ds.Tables["Commandes"]);
            }
            else
            {
                return -1;
            }


        }
    }
}
