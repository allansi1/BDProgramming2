using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryGUI3
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

            //Pour que l'adapteur fasse la definition de clé primaire de la DataTable
            //automatiquemente, mas cela ne marche pas pour les clés étrangères
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds = new DataSet();
            adapter.Fill(ds, "COMPANY");

            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //elemento não visivel que fica entre a table memoire e a table graphique. Vai interceptar muitas funções
            bindingSource1.DataSource = ds.Tables["COMPANY"];
            dataGridView1.DataSource = bindingSource1;

            SqlCommandBuilder buider = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = buider.GetUpdateCommand();

        }


        //valida automaticamente as linhas e a deleção em comparação ao Query2
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            adapter.Update(ds.Tables["COMPANY"]);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition/Modification rejétée");
        }
    }
}
