using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace InteractionWithRedirectionWPF
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

        private async void ResultBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            const string TheProgram = @"G:\Sam\Documents\Source\Repos\StackOverflow\InteractionWithRedirectionTest\bin\Debug\InteractionWithRedirectionTest.exe";
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(TheProgram);
            psi.UseShellExecute = false;
            //psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            p.StartInfo = psi;
            p.Start();
            const string FirstQuestion = "First question: ";
            const string SecondQuestion = "Another question: ";
            const string FinalQuestion = "Final question: ";
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            string Question;
            StringBuilder sb = new StringBuilder("Executing " + TheProgram + "\r\n");
            Question = await sr.ReadLineAsync();
            if (Question != FirstQuestion)
                return;
            sw.WriteLine("First answer");
            sb.Append(Question + "answered\r\n");
            Question = await sr.ReadLineAsync();
            if (Question != SecondQuestion)
                return;
            sw.WriteLine("Second answer");
            sb.Append(Question + "answered\r\n");
            Question = await sr.ReadLineAsync();
            if (Question != FinalQuestion)
                return;
            sw.WriteLine("Final answer");
            sb.Append(Question + "answered\r\n");
            ResultBox.Text = sb.ToString();
        }
    }
}
