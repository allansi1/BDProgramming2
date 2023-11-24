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
                ClientsCommandes.Form1.BLLMessage("Commande réjetée, inférieur à 10.00$");
                
                return -1;
            }
            else
            {
                return Data.EF.SaveChanges();
                
            }
        }
    }
}
