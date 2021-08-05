using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            foreach (Control c in Controls)
            {
                if (c.GetType().Name == "Label")
                    sb.Append(c.Name + " " + c.GetType().Name + "!!!\r\n");
                else
                    sb.Append(c.Name + " " + c.GetType().Name + "\r\n");
            }
            textBox1.Text = sb.ToString();
            MessageBox.Show("Form1_Load");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }
    }
}
