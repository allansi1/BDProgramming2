using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientsCommandes;         // needed for clientsCommandesEntities
using System.Collections.ObjectModel;  // needed for ObservableColections
using System.Data.Entity;  // needed for .Load() 

namespace Data
{
    internal class EF
    {
        private static clientsCommandesEntities db = new clientsCommandesEntities();

        /*
         * To avoid calling <table>.Load() again just because we are shifting between 
         * Clients and Commandes in the GUI, we can use two static variables 
         * (OCClients and OCCommandes) to save the corresponding <table>.Local and 
         * two boolean flags to control if calling <table>.Load() is actually needed
         * to (re)load the corresponding <table>.Local. 
         */

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
            catch (Exception)
            {
                Reload();
                Form1.DALMessage("Impossible de modifier/supprimer ce(s) client(s)");
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
