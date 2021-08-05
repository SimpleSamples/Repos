using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlCommunication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.ButtonClicked = ButtonClicked;
            userControl11.SomethingChanged = SomethingChanged;
        }

        void ButtonClicked(string text)
        {
            label1.Text = text;
        }

        void SomethingChanged(string text)
        {
            label2.Text = text;
        }
    }
}
