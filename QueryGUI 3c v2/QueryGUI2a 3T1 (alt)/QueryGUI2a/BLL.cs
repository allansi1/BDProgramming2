using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPBusiness
{
    class Operate
    {
        //BLL = Business Logic Layer
        internal static void Update()
        {
            //.lengh > 0 quer dizer que pelo menos uma linha é encontrada que satisfaça a condição
            DataTable dt = EMPData.Company.GetData().GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && ((dt.Select("Age < 18").Length > 0) ||(dt.Select("SALARY < 15000").Length > 0)))
            {
                QueryGUI2a.Form1.BLLMessage("Addition/Modification rejété");
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
