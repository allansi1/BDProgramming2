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

namespace Query_GUI2__EF
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

            //Com ToBindingList dá para ler e escrever na base de dados
            db.COMPANY.Load();
            dataGridView1.DataSource = db.COMPANY.Local.ToBindingList();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Insertion/Update rejected");
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
