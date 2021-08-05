using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGVBindToList
{
    public partial class Form1 : Form
    {
        List<dgvdefine> definesds = new List<dgvdefine>();
        BindingSource definesbs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            //
            dgvdefine d;
            d = new dgvdefine();
            d.Name = "One";
            d.Comment = "First";
            definesds.Add(d);
            d = new dgvdefine();
            d.Name = "Two";
            d.Comment = "Second";
            definesds.Add(d);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            definesbs.DataSource = definesds;
            dataGridView1.DataSource = definesbs;
        }
    }

    public class dgvdefine
    {
        //public string Name { get; set; }
        //public string Comment { get; set; }
        public string Name;
        public string Comment;
    }
}
