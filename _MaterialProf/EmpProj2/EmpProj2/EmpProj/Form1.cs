using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpProj2
{
    public partial class Form1 : Form
    {
        internal enum Grids
        {
            Emp,
            Proj,
            Assign
        }

        internal static Form1 current;

        private Grids grid;

        public Form1()
        {
            current = this;
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2();
            Form2.current.Visible = false;
            
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid = Grids.Emp;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.Employees.GetEmployees();
            bindingSource1.Sort = "EmpId";
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns["EmpName"].HeaderText = "Employee Name";
            dataGridView1.Columns["EmpId"].DisplayIndex=0;
            dataGridView1.Columns["EmpName"].DisplayIndex=1;
            dataGridView1.Columns["Salary"].DisplayIndex = 2;

        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid = Grids.Proj;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.Projects.GetProjects();
            bindingSource2.Sort = "ProjId";
            dataGridView1.DataSource = bindingSource2;

            dataGridView1.Columns["ProjName"].HeaderText = "Project Name";
            dataGridView1.Columns["ProjId"].DisplayIndex = 0;
            dataGridView1.Columns["ProjName"].DisplayIndex = 1;
            dataGridView1.Columns["Duration"].DisplayIndex = 2;
        }

        private void assignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid != Grids.Assign)
            {
                grid = Grids.Assign;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource3.DataSource = Data.Assignments.GetDisplayAssignments();
                bindingSource3.Sort = "EmpId, ProjId";    // using bindingSource to sort by two columns
                dataGridView1.DataSource = bindingSource3;
                //dataGridView1.Sort(dataGridView1.Columns["EmpId"], ListSortDirection.Ascending);
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            Business.Employees.UpdateEmployees();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            Business.Projects.UpdateProjects();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            // =========================================================================
            // If the insertion / updated is ended by just changing to another table 
            // (clicking on the menu strip) without clicking on datagrid, we need
            // this event to ensure the database is updated. 
            // =========================================================================
            Business.Employees.UpdateEmployees();
            Business.Projects.UpdateProjects();
        }

        internal static void BLLMessage(string s)
        {
            MessageBox.Show("Business Layer: " + s);
        }

        internal static void DALMessage(string s)
        {
            MessageBox.Show("Data Layer: " + s);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.current.Start(Form2.Modes.INSERT,null);            
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Form2.current.Start(Form2.Modes.UPDATE, c);                
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else // (c.Count > 1)
            {
                List<int[]> lId = new List<int[]>();
                for (int i = 0; i < c.Count; i++)
                {       
                    lId.Add(new int[] { int.Parse("" + c[i].Cells["EmpId"].Value),
                                        int.Parse("" + c[i].Cells["ProjId"].Value) });
                }
                Data.Assignments.DeleteData(lId);
            }
        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for evaluation update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Form2.current.Start(Form2.Modes.EVALUATION, c);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert / update");
            e.Cancel = false;  // includes and "improves" dataGridView1.CancelEdit();
        }
    }
}
