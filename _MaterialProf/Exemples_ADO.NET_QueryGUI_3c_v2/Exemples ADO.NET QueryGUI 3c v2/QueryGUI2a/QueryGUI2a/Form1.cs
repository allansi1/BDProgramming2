using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueryGUI2a
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adapter;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            adapter = new SqlDataAdapter("SELECT * FROM COMPANY", cs.ConnectionString);

            // =========================================================================
            // === Pour que l'adapter fasse la definition de clé primaire de la DataTable 
            // === automatiquement, mais cela ne marche pas pour des clés étrangères
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // ==========================================================================

            ds = new DataSet();
            adapter.Fill(ds, "COMPANY");

            // =========================================================================
            // == Definition manuelle du schema et de la clé primaire
            //ds.Tables["COMPANY"].Columns["ID"].AllowDBNull = false;
            //ds.Tables["COMPANY"].Columns["ID"].Unique = true;
            //ds.Tables["COMPANY"].Columns["NAME"].AllowDBNull = false;
            //ds.Tables["COMPANY"].Columns["AGE"].AllowDBNull = false;
            //ds.Tables["COMPANY"].PrimaryKey = new DataColumn[1] { ds.Tables["COMPANY"].Columns["ID"] };
            // ============================================================================

            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = ds.Tables["COMPANY"];

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            adapter.Update(ds.Tables["COMPANY"]);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            adapter.Update(ds.Tables["COMPANY"]);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition/Modification rejetée");
        }
    }
}
