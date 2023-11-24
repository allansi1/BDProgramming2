using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EMPBusiness
{
    class Operation
    {
        internal static void Update()
        {
            DataTable dt = EMPData.Company.GetData().GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && ((dt.Select("Age < 18").Length > 0) ||
                                 (dt.Select("SALARY < 15000").Length > 0)))
            {
                QueryGUI2a.Form1.BLLMessage("Addition/Modification rejetée");
                EMPData.Company.ReloadData();
            }
            else
            {
                EMPData.Company.UpdateData();               
            }
        }

        internal static void Remove()
        {
            EMPData.Company.UpdateData();           
        }
    }
}
