using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// yes or no prompt not working in console's WinForm
// https://social.msdn.microsoft.com/Forums/en-US/35ac5a44-0658-4d7c-97f6-aa2a303678ac/yes-or-no-prompt-not-working-in-consoles-winform?forum=winforms

namespace WinFormConsole
{
    public partial class Form1 : Form
    {
        // [return: MarshalAs(UnmanagedType.Bool)]
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!AttachConsole(-1))
            {
                string s = new Win32Exception(Marshal.GetLastWin32Error()).ToString();
                MessageBox.Show($"Allocating console; error: {s}");
                AllocConsole();
            }
            // sync all
            Console.WriteLine("Syncing MaxMon");
            Console.WriteLine("Please make sure you are connected to internet.");
            Console.Write("Do you want to Sync all your data now? [y/n] ");

            string risposta = Console.ReadLine();

            if (risposta.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("you choosed YES");
            }
            else
            {
                Console.WriteLine("you choosed NO");
            }
        }
    }
}
