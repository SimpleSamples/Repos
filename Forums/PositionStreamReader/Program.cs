using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionStreamReader
{
    class Program
    {
        static Encoding utf8 = new UTF8Encoding(true);
        static int position = 0;
        static string chunk;

        static void Main(string[] args)
        {
            if (Gulp())
            {
                StringReader sr = new StringReader(chunk);
                string s = sr.ReadLine();
                while (s != null)
                {
                    Console.WriteLine(s);
                    s = sr.ReadLine();
                }
            }
            Console.ReadKey();
            if (Gulp())
            {
                StringReader sr = new StringReader(chunk);
                string s = sr.ReadLine();
                while (s != null)
                {
                    Console.WriteLine(s);
                    s = sr.ReadLine();
                }
            }
        }

        static bool Gulp()
        {
            try
            {
                using (FileStream fs = File.OpenRead(@"G:\Temporary\TextFile2.txt"))
                {
                    int buffersize = (int)fs.Length - position;
                    Byte[] buffer = new Byte[buffersize];
                    Console.WriteLine($"Reading {buffersize} from {position}");
                    fs.Seek((long)position, SeekOrigin.Begin);
                    fs.Read(buffer, 0, buffersize);
                    fs.Close();
                    fs.Dispose();
                    position += buffersize;
                    chunk = utf8.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}
