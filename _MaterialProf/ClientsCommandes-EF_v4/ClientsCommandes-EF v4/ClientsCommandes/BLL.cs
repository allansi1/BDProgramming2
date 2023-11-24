using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class Commandes
    {
        static internal int UpdateCommandes()
        {
            if (Data.EF.GetCommandes().Where(c => (c.Prix < 10)).Count() > 0)
            {
                Data.EF.Reload();
                ClientsCommandes.Form1.BLLMessage("Commande rejetée, inférieur à 10.00 Can$");
                return -1;
            }
            else
            {
                return Data.EF.SaveChanges();                
            }
        }
    }
}
