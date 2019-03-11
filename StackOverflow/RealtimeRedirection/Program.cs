using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeRedirection
{
    class Program
    {
        static void Main(string[] args)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = @"G:\Sam\Documents\Source\Repos\StackOverflow\RealtimeRedirectionTest\bin\Debug\RealtimeRedirectionTest.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };

            var process = Process.Start(processStartInfo);
            var automator = new ConsoleAutomator(process.StandardInput, process.StandardOutput);

            // AutomatorStandardInputRead is your event handler
            automator.StandardInputRead += Automator_StandardInputRead; ;
            automator.StartAutomate();

            // do whatever you want while that process is running
            process.WaitForExit();
            automator.StandardInputRead -= Automator_StandardInputRead;
            process.Close();
        }

        private static void Automator_StandardInputRead(object sender, ConsoleInputReadEventArgs e)
        {
            Console.WriteLine($"Input: {e.Input}, size: {e.Input.Length}");
        }
    }
}
