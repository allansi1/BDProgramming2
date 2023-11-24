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
        internal static int Update()
        {
            DataTable dt = EMPData.Company.GetData().GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && ((dt.Select("Age < 18").Length > 0) ||
                                 (dt.Select("SALARY < 15000").Length > 0)))
            {
                return -1;  // insertion / Update rejected
            }
            else
            {
                EMPData.Company.UpdateData();
                return 0;
            }
        }
    }
}
