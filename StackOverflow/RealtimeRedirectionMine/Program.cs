using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RealtimeRedirectionMine
{
    class Program
    {
        static Stream BinaryStdOut = null;

        static void Main(string[] args)
        {
            const string TheProgram = @"G:\Sam\Documents\Source\Repos\StackOverflow\RealtimeRedirectionTest\bin\Debug\RealtimeRedirectionTest.exe";
            ProcessStartInfo info = new ProcessStartInfo(TheProgram);
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            Console.WriteLine($"Started process {p.Id} {p.ProcessName}");
            BinaryStdOut = p.StandardOutput.BaseStream;
            string Message = null;
            while ((Message = GetMessage()) != null)
                Console.WriteLine(Message);
            p.WaitForExit();
            Console.WriteLine("Done");
        }

        static string GetMessage()
        {
            byte[] Buffer = new byte[80];
            int sizeread = BinaryStdOut.Read(Buffer, 0, Buffer.Length);
            if (sizeread == 0)
                return null;
            return Encoding.UTF8.GetString(Buffer);
        }
    }
}
