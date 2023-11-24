using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryGUI3a
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

            //dataGridView1.DataSource = EMPData.Company.GetData();
            bindingSource1.DataSource = EMPData.Company.GetData();
            dataGridView1.DataSource = bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (EMPBusiness.Operation.Update() == -1)
            {
                MessageBox.Show("Business Rules: Addition/Modification rejetée");
                EMPData.Company.ReInitData();
                bindingSource1.DataSource = EMPData.Company.GetData();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition/Modification rejetée");
        }
    }
}
