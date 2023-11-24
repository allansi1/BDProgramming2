using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class Clients
    {
        internal static int UpdateClients()
        {
            // =========================================================================
            //  Business rules for Clients
            // =========================================================================

            return Data.Clients.UpdateClients();
        }
    }

    internal class Commandes
    {
        internal static int UpdateCommandes()
        {
            // =========================================================================
            //  Business rules for Commandes
            // =========================================================================

            return Data.Commandes.UpdateCommandes();
        }
    }
}
