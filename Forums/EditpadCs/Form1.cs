using System;
using System.IO;
using System.Windows.Forms;

// ToDo: fix design error; if the file is closed then there will be no data
//  but there will be a filename

namespace EditpadCs
{
    public partial class Form1 : Form
    {
        string Filename = null;
        string Previous = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveAs())
            {
                Previous = textBox1.Text;
            }
        }

        /// <summary>
        /// Saves to a file selected by the user
        /// </summary>
        /// <returns>true if something was saved</returns>
        private bool SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file|*.txt|All files|*.*";
            sfd.Title = "Save a text file";
            if (sfd.ShowDialog() != DialogResult.OK)
                return false;
            if (sfd.FileName == "")
                return false;
            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(textBox1.Text);
                    Filename = sfd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Write error: " + ex.Message);
                return false;
            }
            return true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Previous = textBox1.Text;
            }
        }

        /// <summary>
        /// Saves to the file; calls SaveAs if no previous file 
        /// </summary>
        /// <returns>true if something was saved</returns>
        private bool Save()
        {
            if (Filename == null)
            {
                bool saved = SaveAs();
                if (saved)
                {
                    Previous = textBox1.Text;
                }
                return saved;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.FilenameSetting))
                {
                    sw.Write(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Write error: " + ex.Message);
                return false;
            }
            return true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskToSave();
        }

        /// <summary>
        /// If there are unsaved changes then asks to save the changed data.
        /// If the data is saved then the previous file name and edit contents are
        /// removed.
        /// </summary>
        private void AskToSave()
        {
            if (textBox1.Text == Previous)
            {
                Filename = null;
                return;
            }
            DialogResult dr = MessageBox.Show(
                "Do you wish to save changes?",
                "Unsaved changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (dr != DialogResult.Yes)
                return;
            Save();
            Previous = string.Empty;
            Filename = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file|*.txt|All files|*.*";
            ofd.DefaultExt = "txt";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    Previous = sr.ReadToEnd();
                    textBox1.Text = Previous;
                    Filename = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read error: "+ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskToSave();
        }

        //private void toolStripMenuItem1_Click(object sender, EventArgs e) {}
    }
}
