using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    internal class Clients
    {
        internal static int UpdateClients()
        {
            //Business Rules for Clients
           
            return Data.Clients.UpdateClients();
        }
    }

    internal class Commandes
    {
        internal static int UpdateCommandes()
        {
            //Business Rules for Commandes
            DataTable dt = Data.Commandes.GetCommandes().GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && (dt.Select("Prix < 10.0").Length > 0))
            {
                MessageBox.Show("Commande rejétée : La valeur inferieur à $10.00z");
                Data.Commandes.GetCommandes().RejectChanges();
                return -1;
            }
            else
            {
                return Data.Commandes.UpdateCommandes();
            }
           
            
        }
    }

}
