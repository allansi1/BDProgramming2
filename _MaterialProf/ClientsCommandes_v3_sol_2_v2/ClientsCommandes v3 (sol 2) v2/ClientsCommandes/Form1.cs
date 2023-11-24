using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientsCommandes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.Clients.GetClients();
            bindingSource1.Sort = "ClientId";
            dataGridView1.DataSource = bindingSource1;
        }

        private void commandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.Commandes.GetCommandes();
            bindingSource2.Sort = "ComId";
            dataGridView1.DataSource = bindingSource2;

            dataGridView1.Columns["ComId"].HeaderText = "Commande ID";
            dataGridView1.Columns["ComId"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Prix"].DisplayIndex = 2;
            dataGridView1.Columns["ClientId"].DisplayIndex = 3;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Clients.UpdateClients();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Commandes.UpdateCommandes();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            // =========================================================================
            // If the insertion / updated is ended by just changing to the other table 
            // (clicking on the menu strip) without clicking on datagrid, we need
            // this event to ensure the database is updated. 
            // =========================================================================
            BusinessLayer.Clients.UpdateClients();
            BusinessLayer.Commandes.UpdateCommandes();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert / update / delete");
        }

        internal static void msgCommandTooLow()
        {
            MessageBox.Show("Commande rejetée: inférieur à 10.00 Can$");
        }
    }
}
