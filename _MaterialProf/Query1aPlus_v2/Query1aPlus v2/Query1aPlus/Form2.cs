using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query1aPlus
{
    public partial class Form2 : Form
    {
        internal enum Modes
        {
            INSERT,
            UPDATE
        }

        internal static Form2 current;

        private Modes mode = Modes.INSERT;

        public Form2()
        {
            current = this;
            InitializeComponent();
        }

        internal void Start(Modes m, DataGridViewSelectedRowCollection c)
        {
            mode = m;

            if (mode == Modes.INSERT)
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }

            if (mode == Modes.UPDATE)
            {
                textBox1.ReadOnly = true;
                textBox1.Text = "" + c[0].Cells["ID"].Value;
                textBox2.Text = "" + c[0].Cells["NAME"].Value;
                textBox3.Text = "" + c[0].Cells["AGE"].Value;
                textBox4.Text = "" + c[0].Cells["ADDRESS"].Value;
                textBox5.Text = "" + c[0].Cells["SALARY"].Value;
            }

            ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EMPData.Employee emp = new EMPData.Employee();

            if (mode == Modes.INSERT)
            {
                try { emp.Id = int.Parse(textBox1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Id must be an integer");
                    textBox1.Text = "";
                    return;
                }
            }
            if (mode == Modes.UPDATE)
            {
                emp.Id = int.Parse(textBox1.Text);

            }

            emp.Name = textBox2.Text;
            try { emp.Age = int.Parse(textBox3.Text); }
            catch (Exception)
            {
                MessageBox.Show("Age must be an integer");
                textBox3.Text = "";
                return;
            }
            emp.Address = textBox4.Text;
            try { emp.Salary = decimal.Parse(textBox5.Text); }
            catch (Exception)
            {
                MessageBox.Show("Salary must be a decimal number");
                textBox5.Text = "";
                return;
            }

            if (mode == Modes.INSERT) { EMPData.Company.InsertData(emp); }
            if (mode == Modes.UPDATE) { EMPData.Company.UpdateData(emp); }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
