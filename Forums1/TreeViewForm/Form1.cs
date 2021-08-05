using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Parent");
            treeView1.Nodes[0].Nodes.Add("Child 1");
            treeView1.Nodes[0].Nodes.Add("Child 2");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Grandchild 1");
            treeView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Expand();
            treeView1.Nodes[0].Nodes[0].Expand();
            //TreeNode node = treeView1.Nodes[0];
            //if (!node.IsExpanded)
            //{
            //    treeView1.SelectedNode.Expand();
            //}
        }
    }
}
