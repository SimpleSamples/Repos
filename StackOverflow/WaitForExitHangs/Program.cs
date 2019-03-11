using System;
using System.Diagnostics;

// # - ProcessStartInfo hanging on "WaitForExit"? Why? - Stack Overflow
// https://stackoverflow.com/questions/139593/processstartinfo-hanging-on-waitforexit-why

namespace WaitForExitHangs
{
    class Program
    {
        static void Main(string[] args)
        {
            const string TheProgram = @"G:\Sam\Documents\Source\Repos\StackOverflow\WaitForExitHangsTest\bin\Debug\WaitForExitHangsTest.exe";
            Process OurProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Our process is {OurProcess.Id} {OurProcess.ProcessName}");
            ProcessStartInfo info = new ProcessStartInfo(TheProgram);
            info.CreateNoWindow = true;
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            Console.WriteLine($"Process {p.Id} {p.ProcessName}");
            int datasize = 0;
            string record = p.StandardOutput.ReadLine();
            while (record != null)
            {
                datasize += record.Length + 2;
                Console.WriteLine(record);
                record = p.StandardOutput.ReadLine();
            }
            p.WaitForExit();
            string counts = $"{datasize}";
            Console.WriteLine(datasize);
        }
    }
}
