using ExamenFinalQ3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDeptData
{
    
    class Employee
    {
        static EmpDeptEntities db;
        static ObservableCollection<Employees> dOC = null;
        static bool init = false;

        internal static ObservableCollection<Employees> GetData()
        {
            if (!init)
            {
                db = new EmpDeptEntities();
                db.Employees.Load();
                dOC = db.Employees.Local;
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
            catch (Exception ex)
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
    class Department
    {
        static EmpDeptEntities db;
        static ObservableCollection<Departments> dOC = null;
        static bool init = false;

        internal static ObservableCollection<Departments> GetData()
        {
            if (!init)
            {
                db = new EmpDeptEntities();
                db.Departments.Load();
                dOC = db.Departments.Local;
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
            catch (Exception ex)
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
