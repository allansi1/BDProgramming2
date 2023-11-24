using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_BD
{
    public partial class Form1 : Form
    {

        internal enum Mode
        {
            Students,
            Enrollments,
            Courses,
            Programms
        }

        private Mode mode;

        internal static Form1 current;

        public Form1()
        {
            current = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2();
            Form2.current.Visible = false;
            new Form3();
            Form3.current.Visible = false;
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = Mode.Students;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.Students.GetStudents();
            bindingSource1.Sort = "StId";
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns["StId"].HeaderText = "Student Id";
            dataGridView1.Columns["StName"].HeaderText = "Student Name";
            dataGridView1.Columns["ProgId"].HeaderText = "Program Id";
            dataGridView1.Columns["StId"].DisplayIndex = 0;
            dataGridView1.Columns["StName"].DisplayIndex = 1;
            dataGridView1.Columns["ProgId"].DisplayIndex = 2;
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode != Mode.Enrollments)
            {
                mode = Mode.Enrollments;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource2.DataSource = Data.Enrollments.GetDisplayEnrollments();
                bindingSource2.Sort = "StId, CId";    // using bindingSource to sort by two columns
                dataGridView1.DataSource = bindingSource2;
                //dataGridView1.Sort(dataGridView1.Columns["EmpId"], ListSortDirection.Ascending);
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = Mode.Courses;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource3.DataSource = Data.Courses.GetCourses();
            bindingSource3.Sort = "CId";
            dataGridView1.DataSource = bindingSource3;

            dataGridView1.Columns["CId"].HeaderText = "Course Id";
            dataGridView1.Columns["CName"].HeaderText = "Course Name";
            dataGridView1.Columns["ProgId"].HeaderText = "Program Id";
            dataGridView1.Columns["CId"].DisplayIndex = 0;
            dataGridView1.Columns["CName"].DisplayIndex = 1;
            dataGridView1.Columns["ProgId"].DisplayIndex = 2;
        }

        private void programsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = Mode.Programms;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource4.DataSource = Data.Programs.GetPrograms();
            bindingSource4.Sort = "ProgId";
            dataGridView1.DataSource = bindingSource4;

            dataGridView1.Columns["ProgId"].HeaderText = "Program Id";
            dataGridView1.Columns["ProgName"].HeaderText = "Program Name";
            dataGridView1.Columns["ProgId"].DisplayIndex = 0;
            dataGridView1.Columns["ProgName"].DisplayIndex = 1;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(Business.Students.UpdateStudents() == -1)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                bindingSource1.DataSource = Data.Students.GetStudents();
                bindingSource1.Sort = "StId";
                dataGridView1.DataSource = bindingSource1;
            }
        }

        private void bindingSource3_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Courses.UpdateCourses() == -1)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                bindingSource3.DataSource = Data.Courses.GetCourses();
                bindingSource3.Sort = "CId";
                dataGridView1.DataSource = bindingSource3;
            }
        }

        private void bindingSource4_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Programs.UpdatePrograms() == -1)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                bindingSource4.DataSource = Data.Programs.GetPrograms();
                bindingSource4.Sort = "ProgId";
                dataGridView1.DataSource = bindingSource4;
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            Business.Students.UpdateStudents();
            Business.Courses.UpdateCourses();
            Business.Programs.UpdatePrograms();
        }

        internal static void BLLMessage(string s)
        {
            MessageBox.Show("Business Layer: " + s);
        }

        internal static void DALMessage(string s)
        {
            MessageBox.Show("Data Layer: " + s);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data Error: Impossible to insert / update");
            e.Cancel = false;  // includes and "improves" dataGridView1.CancelEdit();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.current.Start(Form2.Modes.INSERT, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
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
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add(new string[] { c[i].Cells["StId"].Value.ToString(),
                                           c[i].Cells["CId"].Value.ToString() });
                }
                Data.Enrollments.DeleteData(lId);
            }
        }

        private void finalGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1 .SelectedRows;
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
                DataGridViewRow row = c[0];
                string stId = "" + row.Cells["StId"].Value;
                string stName = "" + row.Cells["StName"].Value;
                string cId = "" + row.Cells["CId"].Value;
                string cName = "" + row.Cells["CName"].Value;
                string finalGrade = "" + row.Cells["FinalGrade"].Value;

                Form3.current.Start(stId, stName, cId, cName, finalGrade);
                
            }
        }
    }
}
