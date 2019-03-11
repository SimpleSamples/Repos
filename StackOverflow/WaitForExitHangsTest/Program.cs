using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitForExitHangsTest
{
    class Program
    {
        const string Path = @"F:\Migration\Users\Public\Documents\ECMA\Ecma-334.pdf";

        static void Main(string[] args)
        {
            Process OurProcess = Process.GetCurrentProcess();
            Console.Error.WriteLine($"Test process is {OurProcess.Id} {OurProcess.ProcessName}");
            FileInfo fi = null;
            try { fi = new FileInfo(Path); }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Input FileInfo error: " + ex.Message);
                return;
            }
            if (!fi.Exists)
            {
                Console.Error.WriteLine("Input File does not exist");
                return;
            }
            //
            StreamReader stream = null;
            try { stream = new StreamReader(Path); }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Input open error: " + ex.Message);
                return;
            }
            //System.Windows.Forms.MessageBox.Show("Begin");
            Console.SetIn(stream);
            int datasize = 0;
            try
            {
                string record = Console.ReadLine();
                while (record != null)
                {
                    datasize += record.Length + 2;
                    record = Console.ReadLine();
                    Console.WriteLine(record);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return;
            }
            string counts = $"{fi.Length} {datasize}";
            Console.WriteLine(counts);
            Console.Error.WriteLine(counts);
            //System.Windows.Forms.MessageBox.Show(counts);
            //Console.WriteLine("Test line");
        }
    }
}
