using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query_GUI3a_3T1___EF
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

            bindingSource1.DataSource = EMPData.Company.GetData().ToBindingList();
            dataGridView1.DataSource = bindingSource1;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(-1 == EMPBusiness.Operation.Update())
            {
                bindingSource1.DataSource = EMPData.Company.GetData().ToBindingList();

            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data Error: Insertion/Update rejected");
            dataGridView1.CancelEdit();
        }
        internal static void UIMessage(String msg1, String msg2)
        {
            MessageBox.Show(msg1 + "\n" + msg2);
        }
    }
}
