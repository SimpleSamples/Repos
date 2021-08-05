using System;
using System.IO;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"G:\Temporary\t.txt");
            Console.WriteLine(">>>>");
            for (int i = 0; i < 3; ++i)
                Console.WriteLine($"{sr.BaseStream.Position} {sr.ReadLine()}");
            Console.WriteLine("<<<<");
            long pos = sr.BaseStream.Position;
            Console.WriteLine($"At {pos}");
            sr.BaseStream.Seek(pos-10, SeekOrigin.Begin);
            Console.WriteLine(sr.ReadLine());
        }
    }

}
