using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryGUI4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eMPDataSet.COMPANY'. Você pode movê-la ou removê-la conforme necessário.
            this.cOMPANYTableAdapter.Fill(this.eMPDataSet.COMPANY);

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition/Modification rejeté");
        }

        //permite atualizar a tabela ao encerrar o processo
        private void cOMPANYBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.cOMPANYTableAdapter.Update(this.eMPDataSet.COMPANY);
        }
    }
}
