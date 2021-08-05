using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form2 f2 = new Form2();
            //Application.Run(f2);
            //Form1 f1 = new Form1();
            //f1.Filename = f2.Filename;
            Application.Run(new Form1());
        }
    }
}
