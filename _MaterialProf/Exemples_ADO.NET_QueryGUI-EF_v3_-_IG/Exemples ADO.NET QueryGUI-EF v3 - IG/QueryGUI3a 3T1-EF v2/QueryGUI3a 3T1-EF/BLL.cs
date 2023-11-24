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
            // The selection must be done on db.COMPANY.Local, to properly treat insertions.

            // We are going to treat the conditions AGE < 18 and SALARY < 15000 separetely.
            //var r = EMPData.Company.GetData().Where(s => (s.AGE < 18) || (s.SALARY < 15000));

            string msg1 = "";
            string msg2 = "";
            if (EMPData.Company.GetData().Where(s => (s.AGE < 18)).Count() > 0)
            {
                msg1 = "Business Rules: Addition/Modification rejetée.";
                msg2 = "Âge doit être plus grand ou égal à 18 ans.";
                QueryGUI3a_3T1_EF.Form1.UIMessage(msg1, msg2);

                EMPData.Company.ReInitData();  // discard invalid modifications
                return -1;                     // insertion / Update rejected
            }
            else if (EMPData.Company.GetData().Where(s => (s.SALARY < 15000)).Count() > 0)
            {
                msg1 = "Business Rules: Addition/Modification rejetée.";
                msg2 = "Salaire doit être plus grand ou égal à 15000.";
                QueryGUI3a_3T1_EF.Form1.UIMessage(msg1, msg2);

                EMPData.Company.ReInitData();  // discard invalid modifications
                return -1;                     // insertion / Update rejected
            }
            else
            {
                return EMPData.Company.UpdateData();  // sauvegarder les modifications valides
            }
        }
    }
}
