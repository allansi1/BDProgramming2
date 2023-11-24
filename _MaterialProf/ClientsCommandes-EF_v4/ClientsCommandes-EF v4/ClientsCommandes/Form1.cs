using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.ComponentModel;  // needed for ListSortDirection
using System.Data.Entity;  // needed for .ToBindingList()

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

            bindingSource1.DataSource = Data.EF.GetClients().ToBindingList();
            bindingSource1.Sort = "ClientId";
            dataGridView1.DataSource = bindingSource1;
            //dataGridView1.Sort(dataGridView1.Columns["ClientId"], ListSortDirection.Ascending);
        }

        private void commandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.EF.GetCommandes().ToBindingList();
            bindingSource2.Sort = "ComId";
            dataGridView1.DataSource = bindingSource2;
            //dataGridView1.Sort(dataGridView1.Columns["ComId"], ListSortDirection.Ascending);

            dataGridView1.Columns["ComId"].HeaderText = "Commande ID";
            dataGridView1.Columns["ComId"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Prix"].DisplayIndex = 2;
            dataGridView1.Columns["ClientId"].DisplayIndex = 3;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == Data.EF.SaveChanges())
            {
                bindingSource1.DataSource = Data.EF.GetClients().ToBindingList();
                bindingSource1.Sort = "ClientId";
                //dataGridView1.Sort(dataGridView1.Columns["ClientId"], ListSortDirection.Ascending);
            }            
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == BusinessLayer.Commandes.UpdateCommandes())
            {
                bindingSource2.DataSource = Data.EF.GetCommandes().ToBindingList();
                bindingSource2.Sort = "ComId";
                //dataGridView1.Sort(dataGridView1.Columns["ComId"], ListSortDirection.Ascending);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("DataError: Impossible d'ajouter/modifier/supprimer");
            //dataGridView1.CancelEdit();
            e.Cancel = false;  // includes and "improves" dataGridView1.CancelEdit();
        }

        internal static void DALMessage(string msg)
        {
            MessageBox.Show("Data: " + msg);
        }

        internal static void BLLMessage(string msg)
        {
            MessageBox.Show("Business Layer: " + msg);
        }
    }
}
