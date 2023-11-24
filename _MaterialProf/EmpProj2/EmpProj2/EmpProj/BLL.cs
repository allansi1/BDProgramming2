using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    class Employees
    {
        internal static int UpdateEmployees()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["Employees"]
                              .GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && (dt.Select("SALARY < 15000").Length > 0))
            {
                EmpProj2.Form1.BLLMessage("Employee Insertion/Update rejected: Salary less than 15000");
                ds.Tables["Employees"].RejectChanges();
                return -1;
            }
            else
            {
                return Data.Employees.UpdateEmployees();
            }
        }
    }

    class Projects
    {
        internal static int UpdateProjects()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["Projects"]
                              .GetChanges(DataRowState.Added | DataRowState.Modified);
            if ((dt != null) && (dt.Select("Duration < 3").Length > 0))
            {
                EmpProj2.Form1.BLLMessage("Project Insertion/Update rejected: Duration less than 3");
                ds.Tables["Projects"].RejectChanges();
                return -1;
            }
            else
            {
                return Data.Projects.UpdateProjects();
            }
        }
    }

    class Assignments
    {
        internal static int UpdateEvaluation(int[] a, string ev)
        {
            Nullable<int> eval;
            int temp;

            if (ev == "")
            {
                eval = null;                
            }           
            else if (int.TryParse(ev, out temp) && (0<=temp && temp <= 100))
            {
                eval = temp;               
            }
            else
            {
                EmpProj2.Form1.BLLMessage(
                          "Evaluation must be an integer between 0 and 100"
                          );
                return -1;
            }
            
            return Data.Assignments.UpdateEval(a,eval);                 
        }
    }
}
