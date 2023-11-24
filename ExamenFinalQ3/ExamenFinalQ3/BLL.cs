using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDeptBusiness
{
   
    class Employee
    {
            internal static int Update()
            {
                string msg1 = "";
                string msg2 = "";

                if (EmpDeptData.Employee.GetData().Where(s => (s.Salary < 25000)).Count() > 0)
                {
                    msg1 = "Business Rules: Addition /Modification rejected";
                    msg2 = "Salary must be higer ou equal than 25000";
                    ExamenFinalQ3.Form1.UIMessage(msg1, msg2);
                    EmpDeptData.Employee.ReInitData();
                    return -1;
                }
                else
                {
                    return EmpDeptData.Employee.UpdateData();
                }
            }
              
    }
        
}
