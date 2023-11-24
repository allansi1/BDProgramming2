using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Connect;

namespace Data

{
    internal class Connect
    {
        private static String cliComConnectionString = GetConnectString();

        internal static String ConnectionString { get => cliComConnectionString; }
        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en2";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }

        internal class DataTables
        {
            private static SqlDataAdapter adapterStudent = InitAdapterStudent();
            private static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();
            private static SqlDataAdapter adapterDisplayEnrollments = InitAdapterDisplayEnrollments();
            private static SqlDataAdapter adapterCourses = InitAdapterCourses();
            private static SqlDataAdapter adapterProg = InitAdapterProg();
            

            private static DataSet ds = InitDataSet();

            private static SqlDataAdapter InitAdapterStudent()
            {
                SqlDataAdapter r = new SqlDataAdapter(
                    "SELECT * FROM Students ORDER BY StId ",
                    Connect.ConnectionString);

                SqlCommandBuilder builder = new SqlCommandBuilder(r);
                r.UpdateCommand = builder.GetUpdateCommand();

                return r;
            }

            private static SqlDataAdapter InitAdapterEnrollments()
            {
                SqlDataAdapter r = new SqlDataAdapter(
                    "SELECT * FROM enrollments ORDER BY StId, CId ",
                    Connect.ConnectionString);

                SqlCommandBuilder builder = new SqlCommandBuilder(r);
                r.UpdateCommand = builder.GetUpdateCommand();

                return r;
            }

            private static SqlDataAdapter InitAdapterDisplayEnrollments()
            {
                SqlDataAdapter r = new SqlDataAdapter(
                    "SELECT s.StId, s.StName, c.CId, c.CName, a.FinalGrade, p.ProgId, p.ProgName " +
                    "FROM Enrollments a " +
                    "JOIN Students s ON a.StId = s.StId " +
                    "JOIN Courses c ON a.CId = c.CId " +
                    "JOIN Programs p ON s.ProgId = p.ProgId " +
                    "ORDER BY StId, CId ",
                     Connect.ConnectionString);
                

                return r;
            }

            private static SqlDataAdapter InitAdapterCourses()
            {
                SqlDataAdapter r = new SqlDataAdapter(
                    "SELECT * FROM courses ORDER BY CId ",
                    Connect.ConnectionString);

                SqlCommandBuilder builder = new SqlCommandBuilder(r);
                r.UpdateCommand = builder.GetUpdateCommand();

                return r;
            }

            private static SqlDataAdapter InitAdapterProg()
            {
                SqlDataAdapter r = new SqlDataAdapter(
                    "SELECT * FROM programs ORDER BY ProgId ",
                    Connect.ConnectionString);

                SqlCommandBuilder builder = new SqlCommandBuilder(r);
                r.UpdateCommand = builder.GetUpdateCommand();

                return r;
            }

            private static DataSet InitDataSet()
            {
                DataSet ds = new DataSet();
                loadProg(ds);
                loadCourses(ds);
                loadStudents(ds);
                loadEnrollments(ds);
                loadDisplayEnrollments(ds);
                return ds;
            }

            private static void loadStudents(DataSet ds)
            {
                adapterStudent.Fill(ds, "Students");

                // =========================================================================
                ds.Tables["Students"].Columns["StId"].AllowDBNull = false;
                ds.Tables["Students"].Columns["StName"].AllowDBNull = false;

                ds.Tables["Students"].PrimaryKey = new DataColumn[1]
                        { ds.Tables["Students"].Columns["StId"]};
                // =========================================================================

                ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                   new DataColumn[]{
                    ds.Tables["Programs"].Columns["ProgId"]
                   },
                   new DataColumn[] {
                    ds.Tables["Students"].Columns["ProgId"],
                   }
               );
                myFK01.DeleteRule = Rule.Cascade;
                myFK01.UpdateRule = Rule.Cascade;
                ds.Tables["Students"].Constraints.Add(myFK01);
            }

            private static void loadCourses(DataSet ds)
            {
                adapterCourses.Fill(ds, "Courses");

                // =========================================================================
                ds.Tables["Courses"].Columns["CId"].AllowDBNull = false;
                ds.Tables["Courses"].Columns["CName"].AllowDBNull = false;

                ds.Tables["Courses"].PrimaryKey = new DataColumn[1]
                        { ds.Tables["Courses"].Columns["CId"]};
                // =========================================================================

                ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                  new DataColumn[]{
                    ds.Tables["Programs"].Columns["ProgId"]
                  },
                  new DataColumn[] {
                    ds.Tables["Courses"].Columns["ProgId"],
                  }
              );
                myFK01.DeleteRule = Rule.None;
                myFK01.UpdateRule = Rule.Cascade;
                ds.Tables["Courses"].Constraints.Add(myFK01);
            }

            private static void loadProg(DataSet ds)
            {
                adapterProg.Fill(ds, "Programs");

                // =========================================================================
                ds.Tables["Programs"].Columns["ProgId"].AllowDBNull = false;
                ds.Tables["Programs"].Columns["ProgName"].AllowDBNull = false;

                ds.Tables["Programs"].PrimaryKey = new DataColumn[1]
                        { ds.Tables["Programs"].Columns["ProgId"]};
                // =========================================================================
            }

            private static void loadEnrollments(DataSet ds)
            {
                adapterEnrollments.Fill(ds, "Enrollments");

                // =========================================================================
                ds.Tables["Enrollments"].Columns["StId"].AllowDBNull = false;
                ds.Tables["Enrollments"].Columns["CId"].AllowDBNull = false;

                ds.Tables["Enrollments"].PrimaryKey = new DataColumn[2]
                        { ds.Tables["Enrollments"].Columns["StId"], ds.Tables["Enrollments"].Columns["CId"] };

                // =========================================================================  
                /* Foreign Key between DataTables */

                ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                    new DataColumn[]{
                    ds.Tables["Students"].Columns["StId"]
                    },
                    new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["StId"],
                    }
                );
                myFK01.DeleteRule = Rule.Cascade;
                myFK01.UpdateRule = Rule.Cascade;
                ds.Tables["Enrollments"].Constraints.Add(myFK01);

                ForeignKeyConstraint myFK02 = new ForeignKeyConstraint("MyFK02",
                  new DataColumn[]{
                    ds.Tables["Courses"].Columns["CId"]
                  },
                  new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["CId"],
                  }
              );
                myFK02.DeleteRule = Rule.None;
                myFK02.UpdateRule = Rule.Cascade;
                ds.Tables["Enrollments"].Constraints.Add(myFK02);

                // =========================================================================  
            }

            private static void loadDisplayEnrollments(DataSet ds)
            {
                adapterDisplayEnrollments.Fill(ds, "DisplayEnrollments");

                // =========================================================================  
                /* Foreign Key between DataTables */

                ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                    new DataColumn[]{
                    ds.Tables["Students"].Columns["StId"]
                    },
                    new DataColumn[] {
                    ds.Tables["DisplayEnrollments"].Columns["StId"],
                    }
                );
                myFK01.DeleteRule = Rule.Cascade;
                myFK01.UpdateRule = Rule.Cascade;
                ds.Tables["DisplayEnrollments"].Constraints.Add(myFK01);

                ForeignKeyConstraint myFK02 = new ForeignKeyConstraint("MyFK02",
                  new DataColumn[]{
                    ds.Tables["Courses"].Columns["CId"]
                  },
                  new DataColumn[] {
                    ds.Tables["DisplayEnrollments"].Columns["CId"],
                  }
              );
                myFK02.DeleteRule = Rule.None;
                myFK02.UpdateRule = Rule.None;
                ds.Tables["DisplayEnrollments"].Constraints.Add(myFK02);

                // ========================================================================= 
            }


            internal static SqlDataAdapter getAdapterStudents()
            {
                return adapterStudent;
            }
            internal static SqlDataAdapter getAdapterEnrollments()
            {
                return adapterEnrollments;
            }
            internal static SqlDataAdapter getAdapterCourses()
            {
                return adapterCourses;
            }
            internal static SqlDataAdapter getAdapterProg()
            {
                return adapterProg;
            }

            internal static SqlDataAdapter getAdapterDisplayEnrollments()
            {
                return adapterDisplayEnrollments;
            }

            internal static DataSet getDataSet()
            {
                return ds;
            }

        }

    }

    internal class Students
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterStudents();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetStudents()
        {
            return ds.Tables["Students"];
        }

        internal static int UpdateStudents()
        {
            if (!ds.Tables["Students"].HasErrors)
            {
                return adapter.Update(ds.Tables["Students"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Enrollments
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterEnrollments();
        private static DataSet ds = DataTables.getDataSet();

        private static DataTable displayEnrollments = null;

        internal static DataTable GetDisplayEnrollments()
        {
            displayEnrollments = ds.Tables["DisplayEnrollments"];
            return displayEnrollments;
        }

        internal static int InsertData(string[] a)
        {
            var test = (
                   from enrollment in ds.Tables["Enrollments"].AsEnumerable()
                   where enrollment.Field<string>("StId") == a[0]
                   where enrollment.Field<string>("CId") == a[1]
                   select enrollment);
            if (test.Count() > 0)
            {
                TP2_BD.Form1.DALMessage("This enrollment already exists");
                return -1;
            }
            try
            {
                DataRow line = ds.Tables["Enrollments"].NewRow();
                line.SetField("StId", a[0]);
                line.SetField("CId", a[1]);
                ds.Tables["Enrollments"].Rows.Add(line);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollments != null)
                {
                    //LINQ - EX. 06 - inner join - first form
                    var query = from enrollment in ds.Tables["Enrollments"].AsEnumerable()
                                join student in ds.Tables["Students"].AsEnumerable()
                                on enrollment.Field<string>("StId") equals a[0]
                                join course in ds.Tables["Courses"].AsEnumerable()
                                on enrollment.Field<string>("CId") equals a[1]
                                join program in ds.Tables["Programs"].AsEnumerable() 
                                on student.Field<string>("ProgId") equals program.Field<string>("ProgId")
                                select new
                                {
                                    StId = student.Field<string>("StId"),
                                    StName = student.Field<string>("StName"),
                                    CId = course.Field<string>("CId"),
                                    CName = course.Field<string>("CName"),
                                    FinalGrade = enrollment.Field<int?>("FinalGrade"),
                                    ProgId = program.Field<string>("ProgId"),
                                    ProgName = program.Field<string>("ProgName")
                                };
                    // Note that Eval =line.Field<Nullable<int>>("Eval") will 
                    // always place null in Eval. It is not needed. 
                    // It is enough to ommit Eval in the select and  
                    // ommit r.Eval in displayAssign.Rows.Add(...)
                    var r = query.Single();
                    displayEnrollments.Rows.Add(new object[] { r.StId, r.StName, r.CId, r.CName, r.FinalGrade, r.ProgId, r.ProgName  });
                }
                return 0;
            }
            catch (Exception)
            {
                TP2_BD.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }

        }

        internal static int DeleteData(List<string[]> lId)
        {
            try
            {
                var lines = ds.Tables["Enrollments"].AsEnumerable()
                                .Where(s =>
                                   lId.Any(x => (x[0] == s.Field<string>("StId") && x[1] == s.Field<string>("CId"))));

                foreach (var line in lines)
                {
                    line.Delete();
                }

                adapter.Update(ds.Tables["Assignments"]);

                if (displayEnrollments != null)
                {
                    foreach (var p in lId)
                    {
                        var r = displayEnrollments.AsEnumerable()
                                .Where(s => (s.Field<string>("StId") == p[0] && s.Field<string>("CId") == p[1]))
                                .Single();
                        displayEnrollments.Rows.Remove(r);
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                TP2_BD.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }

        internal static int UpdateGrade(string[] a, Nullable<int> grade)
        {
            try
            {
                var line = ds.Tables["Enrollments"].AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                                    .Single();

                line.SetField("GradeFinal", grade);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollments != null)
                {
                    var r = displayEnrollments.AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                                    .Single();
                    r.SetField("Eval", grade);
                }
                return 0;
            }
            catch (Exception)
            {
                TP2_BD.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }

    }

    internal class Courses
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCourses();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetCourses()
        {
            return ds.Tables["Courses"];
        }

        internal static int UpdateCourses()
        {
            if (!ds.Tables["Courses"].HasErrors)
            {
                return adapter.Update(ds.Tables["Courses"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Programs
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterProg();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetPrograms()
        {
            return ds.Tables["Programs"];
        }

        internal static int UpdatePrograms()
        {
            if (!ds.Tables["Programs"].HasErrors)
            {
                return adapter.Update(ds.Tables["Programs"]);
            }
            else
            {
                return -1;
            }
        }
    }
}
