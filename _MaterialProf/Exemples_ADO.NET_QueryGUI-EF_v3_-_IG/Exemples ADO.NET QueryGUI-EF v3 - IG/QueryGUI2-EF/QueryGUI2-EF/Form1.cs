using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;  // needed to .Load and .ToBindingList()

namespace QueryGUI2_EF
{
    public partial class Form1 : Form
    {
        static EMPEntities db = new EMPEntities();

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

            db.COMPANY.Load();
            dataGridView1.DataSource = db.COMPANY.Local.ToBindingList();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Insertion/Update rejected");
                /* 
                 * We need a better way to treat an invalid insertion / update.
                 * We can not re-assign dataGridView1.DataSource from within this event
                 * We can not "reject change" in an easy way, because we are not working directly with 
                 * DataSets and DataTables. 
                 * The easiest solution is to use the BindingSource component (see example 3).
                 */
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            db.SaveChanges();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data Error: Insertion/Update rejected");
            dataGridView1.CancelEdit();
        }
    }
}
