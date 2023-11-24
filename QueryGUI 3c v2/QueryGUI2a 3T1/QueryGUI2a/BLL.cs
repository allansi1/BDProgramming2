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
        internal static int Update()
        {
            //.lengh > 0 quer dizer que pelo menos uma linha é encontrada que satisfaça a condição
            DataTable dt = EMPData.Company.GetData().GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && ((dt.Select("Age < 18").Length > 0) ||(dt.Select("SALARY < 15000").Length > 0)))
            {
                return -1;
            }
            else
            {
                EMPData.Company.UpdateData();
                return 0;
            }
            
        }
        internal static int Remove()
        {
            EMPData.Company.UpdateData();
            return 0;
        }

    }
}
