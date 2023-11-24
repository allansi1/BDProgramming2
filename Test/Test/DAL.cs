using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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
            cs.InitialCatalog = "EtudCours";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;

        }
    }

    internal class DataTables
    {

        internal static SqlDataAdapter adapterStudent = InitAdapterStudents();
        internal static SqlDataAdapter adapterCours = InitAdapterCours();
        internal static SqlDataAdapter adapterInscription = InitAdapterInscription();
        private static DataSet ds = InitDataSet();


        private static SqlDataAdapter InitAdapterStudents()
        {
            SqlDataAdapter r = new SqlDataAdapter("SELECT * FROM etudiants ORDER BY E_Id", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;
        }
        private static SqlDataAdapter InitAdapterCours()
        {
            SqlDataAdapter r = new SqlDataAdapter("SELECT * FROM cours ORDER BY C_Id", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;

        }

        private static SqlDataAdapter InitAdapterInscription()
        {
            SqlDataAdapter r = new SqlDataAdapter("SELECT * FROM inscription ORDER BY E_Id", Connect.ConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();
            return r;

        }
        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            loadStudents(ds);
            loadCours(ds);
            loadInscription(ds);
            return ds;
        }
        private static void loadStudents(DataSet ds)
        {
            adapterStudent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterStudent.Fill(ds, "Etudiants");
        }
        private static void loadCours(DataSet ds)
        {
            adapterCours.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterCours.Fill(ds, "Cours");
        }

        private static void loadInscription(DataSet ds)
        {
            adapterInscription.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterInscription.Fill(ds, "Inscription");

            ForeignKeyConstraint FK_Etud = new ForeignKeyConstraint("FK_Etud",
                new DataColumn[]
                {
                        ds.Tables["Etudiants"].Columns["E_Id"]
                }, new DataColumn[]
                {
                        ds.Tables["Inscription"].Columns["E_Id"],
                }
                );
            FK_Etud.DeleteRule = Rule.Cascade;
            FK_Etud.UpdateRule = Rule.Cascade;
            ds.Tables["Inscription"].Constraints.Add(FK_Etud);

            ForeignKeyConstraint FK_Cours = new ForeignKeyConstraint("FK_Cours",
                new DataColumn[]
                {
                        ds.Tables["Cours"].Columns["C_Id"]
                }, new DataColumn[]
                {
                        ds.Tables["Inscription"].Columns["C_Id"],
                }
                );
            FK_Cours.DeleteRule = Rule.None;
            FK_Cours.UpdateRule = Rule.None;
            ds.Tables["Inscription"].Constraints.Add(FK_Cours);
        }

        internal static SqlDataAdapter getAdapterStudent()
        {
            return adapterStudent;
        }

        internal static SqlDataAdapter getAdapterCours()
        {
            return adapterCours;
        }

        internal static SqlDataAdapter getAdapterInscription()
        {
            return adapterInscription;
        }

        internal static DataSet GetDataSet()
        {
            return ds;
        }

       
    }
    internal class Student
    {
        private static SqlDataAdapter adapterStudent = DataTables.getAdapterStudent();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetSudents()
        {
            return ds.Tables["Etudiants"];
        }
        internal static int UpdateStudent()
        {
            if (!ds.Tables["Etudiants"].HasErrors)
            {
                return adapterStudent.Update(ds.Tables["Etudiants"]);
            }
            else
            {
                return -1;
            }
        }

    }

    internal class Cours
    {
        private static SqlDataAdapter adapterCours = DataTables.getAdapterCours();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetCours()
        {
            return ds.Tables["Cours"];
        }
        internal static int UpdateCours()
        {
            if (!ds.Tables["Cours"].HasErrors)
            {
                return adapterCours.Update(ds.Tables["Cours"]);
            }
            else
            {
                return -1;
            }
        }

    }

    internal class Inscription
    {
        private static SqlDataAdapter adapterInscription = DataTables.getAdapterInscription();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetInscription()
        {
            return ds.Tables["Inscription"];
        }
        internal static int UpdateInscription()
        {
            if (!ds.Tables["Inscription"].HasErrors)
            {
                return adapterInscription.Update(ds.Tables["Inscription"]);
            }
            else
            {
                return -1;
            }
        }

    }
}
