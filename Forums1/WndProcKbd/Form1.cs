using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// How can I measure the elapsed time between same keys presses ?
// https://social.msdn.microsoft.com/Forums/windows/en-US/5527f1a6-9e5c-4fc7-a2eb-33cf29bbb571/how-can-i-measure-the-elapsed-time-between-same-keys-presses-?forum=winforms#a7e2c67f-eb98-4aab-a520-c749a4814dfb

namespace WndProcKbd
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int GetMessageTime();

        double Previous = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            double Current = GetMessageTime();
            double Difference = (Current - Previous) / 1000;
            textBox2.Text = Difference.ToString();
            Previous = Current;
        }
    }
}
