using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_BD;

namespace Business
{

    class Students
    {

        internal static int UpdateStudents()
        {
            DataSet ds = Data.Connect.DataTables.getDataSet();
            DataTable dt = ds.Tables["Students"].GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    if (!CheckStId(dr.Field<string>("StId")))
                    {
                       TP2_BD.Form1.BLLMessage("Invalid Student Id: " + dr.Field<string>("StId"));
                       ds.Tables["Students"].Rows.Find(dr.Field<string>("StId")).Delete();
                       ds.Tables["Students"].AcceptChanges();
                       return -1;
                    }

                }
            }
            return Data.Students.UpdateStudents();
        }
        private static bool CheckStId(string stId)
        {
            bool r = true;
            if (stId.Length != 10) {r = false;}
            else if (stId[0] != 'S') { r = false; }
            else 
            {
                for (int i = 1; i < stId.Length; i++)
                {
                    r = r && Char.IsDigit(stId[i]);
                }
            }
            return r;
            
        }

    }

    class Programs
    {

        internal static int UpdatePrograms()
        {
            DataSet ds = Data.Connect.DataTables.getDataSet();
            DataTable dt = ds.Tables["Programs"].GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!CheckProgId(dr.Field<string>("ProgId")))
                    {
                        TP2_BD.Form1.BLLMessage("Invalid Program Id: " + dr.Field<string>("ProgId"));
                        ds.Tables["Programs"].Rows.Find(dr.Field<string>("ProgId")).Delete();
                        ds.Tables["Programs"].AcceptChanges();
                        return -1;
                    }

                }
            }
            return Data.Programs.UpdatePrograms();
        }
        private static bool CheckProgId(string progId)
        {
            bool r = true;
            if (progId.Length != 5) { r = false; }
            else if (progId[0] != 'P') { r = false; }
            else
            {
                for (int i = 1; i < progId.Length; i++)
                {
                    r = r && Char.IsDigit(progId[i]);
                }
            }
            return r;

        }
    }

    class Courses
    {

        internal static int UpdateCourses()
        {
            DataSet ds = Data.Connect.DataTables.getDataSet();
            DataTable dt = ds.Tables["Courses"].GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!CheckCId(dr.Field<string>("CId")))
                    {
                        TP2_BD.Form1.BLLMessage("Invalid Course Id: " + dr.Field<string>("CId"));
                        ds.Tables["Courses"].Rows.Find(dr.Field<string>("CId")).Delete();
                        ds.Tables["Courses"].AcceptChanges();
                        return -1;
                    }

                }
            }
            return Data.Courses.UpdateCourses();
        }
        private static bool CheckCId(string CId)
        {
            bool r = true;
            if (CId.Length != 7) { r = false; }
            else if (CId[0] != 'C') { r = false; }
            else
            {
                for (int i = 1; i < CId.Length; i++)
                {
                    r = r && Char.IsDigit(CId[i]);
                }
            }
            return r;

        }
    }


    class Enrollments
        {
            internal static int UpdateGrade(string[] a, string gr)
            {
                Nullable<int> grade;
                int temp;
                if(gr == "")
                {
                    grade = null;
                }
                else if (int.TryParse(gr,out temp) && (0<=temp && temp<=100))
                {
                    grade = temp;
                }
                else
                {
                    TP2_BD.Form1.BLLMessage("Final grade must be an integer between 0 and 100");
                    return -1;
                }

            
                return Data.Enrollments.UpdateGrade(a, grade);
            }
            
            internal static bool HasFinalGrade()
            {
                DataSet ds = Data.Connect.DataTables.getDataSet();
                DataTable dt = ds.Tables["Enrollments"].GetChanges(DataRowState.Added | DataRowState.Modified);
                if ((dt != null) && (dt.Select("FinalGrade IS NOT NULL").Length > 0))
                {
                   return true ;
                }
                else
                {
                   return false ;
                }

            }
        }

      
}
