using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RediretStdIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (Process ChatterBodies = new Process())
            //{
            //    ChatterBodies.StartInfo.FileName = exepath;
            //    ChatterBodies.StartInfo.UseShellExecute = false;
            //    ChatterBodies.StartInfo.RedirectStandardInput = true;
            //    ChatterBodies.StartInfo.RedirectStandardOutput = true;
            //    // ChatterBodies.OutputDataReceived += ChatterBodies_OutputDataReceived;
            //    ChatterBodies.Start();
            //    ChatterIn = ChatterBodies.StandardInput.BaseStream;
            //    ChatterOut = ChatterBodies.StandardOutput.BaseStream;
            //    //ChatterBodies.BeginOutputReadLine();
            //    JObject JoMessage = null;
            //    SendMessage("Hello");
            //    //DoneEvent.WaitOne();
            //    //Thread.Sleep(500);
            //    JoMessage = GetMessage();
            //    SendMessage("Bye");
            //    JoMessage = GetMessage();
            //    //DoneEvent.WaitOne();
            //}
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "ssh.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
               Arguments = "visitor@localhost"
            };

            process.StartInfo = psi;
            try { process.Start(); }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            using (System.IO.StreamWriter sw = process.StandardInput)
            {
                //sw.WriteLine("ls".Replace("/r/n", "/n"));
                sw.WriteLine("testssh");
                sw.WriteLine("dir");
            }

            process.WaitForExit();
        }
    }
}
