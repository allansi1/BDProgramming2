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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //elemento não visivel que fica entre a table memoire e a table graphique. Vai interceptar muitas funções
            bindingSource1.DataSource = EMPData.Company.GetData();
            dataGridView1.DataSource = bindingSource1;
                       
        }


        //valida automaticamente as linhas e a deleção em comparação ao Query2
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            EMPData.Company.UpdateData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition/Modification rejétée");
        }
    }
}
