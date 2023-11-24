using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;                     
            bindingSource1.DataSource = Data.Student.GetSudents();
            bindingSource1.Sort = "E_Id";
            dataGridView1.DataSource = bindingSource1;
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bindingSource2.DataSource = Data.Cours.GetCours();
            bindingSource2.Sort = "C_Id";
            dataGridView1.DataSource = bindingSource2;
        }

        private void inscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bindingSource3.DataSource = Data.Inscription.GetInscription();
            bindingSource3.Sort = "E_Id";
            dataGridView1.DataSource = bindingSource3;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            Data.Student.UpdateStudent();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            Data.Cours.UpdateCours();
        }

        private void bindingSource3_CurrentChanged(object sender, EventArgs e)
        {
            //Data.Inscription.UpdateInscription();
            BusinessLayer.Inscription.UpdateInscription();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            Data.Student.UpdateStudent();
            Data.Cours.UpdateCours();
            //Data.Inscription.UpdateInscription();
            BusinessLayer.Inscription.UpdateInscription();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible/erreur");
        }
    }
}
