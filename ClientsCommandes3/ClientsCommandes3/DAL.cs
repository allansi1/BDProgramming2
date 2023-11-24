using ClientsCommandes3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class EF
    {
        //EF = Entity Framework
        static clientsCommandesEntities db = new clientsCommandesEntities();
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

        internal static void SaveChanges()
        {
            db.SaveChanges();
        }

        internal static void Reload() 
        {
            db = new clientsCommandesEntities();
            initClients = false;
            initCommandes = false;
        }

    }
}
