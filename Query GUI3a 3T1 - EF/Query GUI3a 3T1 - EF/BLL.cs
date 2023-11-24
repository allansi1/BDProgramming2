using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPBusiness
{
    class Operation
    {
        internal static int Update()
        {
            string msg1 = "";
            string msg2 = "";

            if(EMPData.Company.GetData().Where(s => (s.AGE<18)).Count() > 0)
            {
                msg1 = "Business Rules: Addition /Modification rejected";
                msg2 = "Age must be higer ou equal than 18 years old";
                Query_GUI3a_3T1___EF.Form1.UIMessage(msg1, msg2);
                EMPData.Company.ReInitData();
                return -1;
            }
            else if (EMPData.Company.GetData().Where(s => (s.SALARY < 15000)).Count()>0) 
            {
                msg1 = "Business Rules: Addition /Modification rejected";
                msg2 = "Salary must be higer ou equal than 15000";
                Query_GUI3a_3T1___EF.Form1.UIMessage(msg1, msg2);
                EMPData.Company.ReInitData();
                return -1;
            }
            else
            {
                return EMPData.Company.UpdateData();
            }
           
        }
    }
}
