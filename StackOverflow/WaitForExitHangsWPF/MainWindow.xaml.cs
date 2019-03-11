using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaitForExitHangsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            const string TheProgram = @"G:\Sam\Documents\Source\Repos\StackOverflow\WaitForExitHangsTest\bin\Debug\WaitForExitHangsTest.exe";
            ProcessStartInfo info = new ProcessStartInfo(TheProgram);
            //info.CreateNoWindow = true;
            //info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            StringBuilder sb = new StringBuilder($"Process {p.Id} {p.ProcessName}");
            int datasize = 0;
            string record = p.StandardOutput.ReadLine();
            while (record != null)
            {
                datasize += record.Length + 2;
                sb.Append(record);
                record = p.StandardOutput.ReadLine();
            }
            ResultBox.Text = sb.ToString();
            //p.WaitForExit();
            //ResultBox.Text = p.StandardOutput.ReadToEnd();
        }
    }
}
