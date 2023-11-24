using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPBusiness
{
    internal class Operation
    {

        internal static bool IsValid(EMPData.Employee emp)
        {
            if(!(emp.Age<18|| emp.Salary < 15000))
                    {
                return true;
            }
            else 
            {
                Query1aPlus.Form1.UIMessage("Business Rules: Addition/Modification rejected");
                return false;
            }
        }
    }
}
