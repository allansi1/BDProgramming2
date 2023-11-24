using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    internal class Department
    {
        internal static int UpdateDept()
        {
            //Business Rules for Dept

            return Data.Department.UpdateDept();
        }
    }

    internal class Employe
    {
        
        internal static int UpdateEmp()
        {
            //Business Rules for Dept
            DataTable dt = Data.Employe.GetEmp().GetChanges(DataRowState.Added | DataRowState.Modified);

            if ((dt != null) && ((dt.Select("Age < 18 OR Age > 120").Length > 0) ||
                                 (dt.Select("SALARY <= 15000").Length > 0)))
            {
                if (dt.Select("Age < 18 OR Age > 120").Length > 0)
                {
                    Data.Department.GetDept().RejectChanges();
                    MessageBox.Show("L'âge de l'employé doit être compris entre 18 et 120 ans.");
                    
                }

                if (dt.Select("SALARY <= 15000").Length > 0)
                {
                    Data.Department.GetDept().RejectChanges();
                    MessageBox.Show("Le salaire d'un employé ne peut pas être inférieur ou égal à $15000,00");
                    
                }


               
                return -1;
            }
            else
            {
                return Data.Employe.UpdateEmp();
            }

            
        }


    }
}
