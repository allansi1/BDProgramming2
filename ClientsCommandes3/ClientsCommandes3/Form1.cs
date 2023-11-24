﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientsCommandes3
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

            dataGridView1.Columns["ComId"].HeaderText = "Commande Id";
            dataGridView1.Columns["ComId"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Prix"].DisplayIndex = 2;
            dataGridView1.Columns["ClientId"].DisplayIndex = 3;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            //Try Catch para tentar salvar mudanças
            
            try
            {
                Data.EF.SaveChanges();
            }
            catch (Exception)
            {
                Data.EF.Reload();
                bindingSource1.DataSource = Data.EF.GetClients().ToBindingList();
                bindingSource1.Sort = "ClientId";
                MessageBox.Show("Impossible de modifier/supprimer ce(s) client(s)");
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == BusinessLayer.Commandes.UpdateCommandes())
            {
                bindingSource2.DataSource = Data.EF.GetCommandes().ToBindingList();
                bindingSource2.Sort = "ComId";
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data Error: Impossible d'ajouter/modifier/supprimer");
            dataGridView1.CancelEdit();
            //Ao insirir "aaa" no preço, ao trocar de tabela, ele cancela a modificação
            e.Cancel = false;

        }

        internal static void BLLMessage(string msg)
        {
            MessageBox.Show("Business Error" + msg);
        }
    }
}
