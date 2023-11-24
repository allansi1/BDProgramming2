using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientsCommandes;

namespace Data
{
    internal class EF
    {
        private static clientsCommandesEntities db = new clientsCommandesEntities();
        private static ObservableCollection<Clients> OCClients = null;
        private static bool initClients = false;

        private static ObservableCollection<Commandes> OCCommandes = null;
        private static bool initCommandes = false;

        internal static ObservableCollection<Clients> GetClients()
        {
            if (!initClients)
            {
                db.Clients.Load();
                OCClients = db.Clients.Local;
                initClients = true;
            }
            return OCClients;
        }

        internal static ObservableCollection<Commandes> GetCommandes()
        {
            if (!initCommandes)
            {
                db.Commandes.Load();
                OCCommandes = db.Commandes.Local;
                initCommandes = true;
            }
            return OCCommandes;
        }

        internal static int SaveChanges()
        {
            try
            {
                db.SaveChanges();
                return 0;
            }
            catch(Exception) 
            {
                Reload();
                Form1.DALMessage("Impossible de ajouter/modifier/supprimer");
                return -1;
            }
            
           
        }

        internal static void Reload() 
        {
            db = new clientsCommandesEntities();
            initClients = false;
            initCommandes = false;
        }


    }
}
