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
    public partial class Form3 : Form
    {

        internal static Form3 current;
        private string[] enrollInitial;

        public Form3()
        {
            current = this;
            InitializeComponent();
        }

        internal void Start(string stId, string stName, string cId, string cName, string finalGrade)
        {

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            textBox1.Text = stId;
            textBox2.Text = stName;
            textBox3.Text = cId;
            textBox4.Text = cName;
            textBox5.Text = finalGrade;
            enrollInitial = new string[] { stId, cId };
            ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = -1;
            Business.Enrollments.UpdateGrade(enrollInitial,textBox5.Text);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
