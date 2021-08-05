using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlCommunication
{
    public partial class UserControl1 : UserControl
    {
        public delegate void ButtonClickedEvent(string text);
        public ButtonClickedEvent ButtonClicked = null;
        public delegate void SomethingChangedEvent(string text);
        public SomethingChangedEvent SomethingChanged = null;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke("Button clicked at "+DateTime.Now.ToString());
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            SomethingChanged?.Invoke(textBox1.Text);
        }
    }
}
