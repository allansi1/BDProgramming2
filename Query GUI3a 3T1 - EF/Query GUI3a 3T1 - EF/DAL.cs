using Query_GUI3a_3T1___EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPData
{
    class Company
    {
        static EMPEntities db;
        static ObservableCollection<COMPANY> dOC = null; // variable pour garder la list de lignes
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
                Form1.UIMessage("Data: Rejected insetion/update", "");
                ReInitData();
                return -1;
            }

        }
        internal static void ReInitData()
        {
            init = false;
        }

    }
}
