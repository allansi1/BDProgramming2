using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query1aPlus
{
    public partial class Form1 : Form
    {
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

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void cOMPANYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = EMPData.Company.GetData();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.current.Start(Form2.Modes.INSERT, null);
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
                MessageBox.Show("At least one line must be selected for delete");
            }
            else
            { 
                List<int> lId = new List<int>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add((int)c[i].Cells["ID"].Value);
                }
                EMPData.Company.DeleteData(lId);
            }
           
        }

        internal static void UIMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
