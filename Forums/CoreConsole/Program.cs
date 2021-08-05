using System;
using System.IO;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] lines = { "First line", "Second line", "Third line" };
            File.WriteAllLines("WriteLines.txt", lines);
        }
    }

}
