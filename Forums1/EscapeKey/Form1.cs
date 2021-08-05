using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ok");
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not ok");
            Close();
        }
    }
}
