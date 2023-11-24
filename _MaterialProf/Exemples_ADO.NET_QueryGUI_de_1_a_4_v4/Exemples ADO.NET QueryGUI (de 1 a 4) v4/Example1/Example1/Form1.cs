using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool flag = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                textBox1.Text = "Hello World!!";
                button1.Text = "Clear";
                flag = false;
            }
            else
            {
                textBox1.Text = "";
                button1.Text = "Click me";
                flag = true;
            }
        }
    }
}
