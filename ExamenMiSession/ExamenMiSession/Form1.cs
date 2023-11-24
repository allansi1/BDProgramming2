using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenMiSession
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //important
            bindingSource1.DataSource = Data.Department.GetDept();
            bindingSource1.Sort = "DeptId";
            dataGridView1.DataSource = bindingSource1;

        }

        private void employeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //important
            bindingSource2.DataSource = Data.Employe.GetEmp();
            bindingSource2.Sort = "EmpId";
            dataGridView1.DataSource = bindingSource2;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Department.UpdateDept();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Employe.UpdateEmp();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            BusinessLayer.Department.UpdateDept();
            BusinessLayer.Employe.UpdateEmp();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert/update/delete");
        }
    }
}
