using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientsCommands_v2
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


        //Clicar na janela, ir em eventos e load
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //important
            bindingSource1.DataSource = Data.Clients.GetClients();
            bindingSource1.Sort = "ClientId";
            dataGridView1.DataSource=bindingSource1;

        }

        private void commandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //important
            bindingSource2.DataSource = Data.Commandes.GetCommandes();
            bindingSource2.Sort = "ComId";
            dataGridView1.DataSource = bindingSource2;

            dataGridView1.Columns["ComId"].HeaderText = "Commande Id";
            dataGridView1.Columns["ComId"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].DisplayIndex= 1;
            dataGridView1.Columns["Prix"].DisplayIndex = 2;
            dataGridView1.Columns["ClientId"].DisplayIndex = 3;
        }

        //clicar no bindSource no Design, proprietés e current changes
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Clients.UpdateClients();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Commandes.UpdateCommandes();
        }


        //GridView > Proprietés > Eventos > DataSourceChanged
        //Serve para corrigir se ao atualizar uma linha na interface gráfica, ao clicar na aba para ir pra próxima tabela
        //atualiza as 2 tabelas
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            BusinessLayer.Clients.UpdateClients();
            BusinessLayer.Commandes.UpdateCommandes();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert/update/delete");
        }
    }
}
