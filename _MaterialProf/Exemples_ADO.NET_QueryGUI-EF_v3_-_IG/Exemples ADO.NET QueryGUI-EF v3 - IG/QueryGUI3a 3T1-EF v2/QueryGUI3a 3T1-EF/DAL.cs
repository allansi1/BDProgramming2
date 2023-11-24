using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryGUI3a_3T1_EF;  // pour EMPEntities
using System.Data.Entity;  // needed to .Load and .ToBindingList()
using System.Collections.ObjectModel; // needed to ObservableCollection<>


namespace EMPData
{
    class Company
    {
        static EMPEntities db;
        static ObservableCollection<COMPANY> dOC = null;
        static bool init = false;

        internal static ObservableCollection<COMPANY> GetData()
        {
            if (!init)
            {
                db = new EMPEntities();
                db.COMPANY.Load();
                dOC = db.COMPANY.Local;
                init = true;
            }
            return dOC;
        }

        internal static int UpdateData()
        {
            try
            {
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                Form1.UIMessage("Data: Addition/Modification rejetée", "");
                ReInitData();          // discard invalid modifications
                return -1;             // insertion / Update rejected
            }
        }

        internal static void ReInitData()
        {
            init = false;
        }
    }
}
