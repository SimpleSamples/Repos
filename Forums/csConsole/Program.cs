using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // byte[] result;
            //FileStream SourceStream = File.Open(@"c:\Temp\userinputlog.txt", FileMode.Open);
            // result = new byte[SourceStream.Length];
            // Console.WriteLine(result);
            string strValue = ReadOperation().Result;
            Console.WriteLine(strValue);
        }

        public async static Task<string> ReadOperation()
        {
            var ret = await File.ReadAllTextAsync("C:\\Users\\user\\Desktop\\file.txt");
            return ret;
        }
    }
}
