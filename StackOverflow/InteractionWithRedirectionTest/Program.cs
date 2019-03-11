using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionWithRedirectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter log = new StreamWriter("InteractionWithRedirectionTest.txt");
            //FileInfo fi = new FileInfo("InteractionWithRedirectionTest.txt");
            //System.Windows.Forms.MessageBox.Show(fi.DirectoryName);
            string Answer;
            Console.Out.WriteLine("First question: ");
            Answer = Console.In.ReadLine();
            log.WriteLine("First is " + Answer);
            Console.Out.WriteLine("Another question: ");
            Answer = Console.In.ReadLine();
            log.WriteLine("The other is " + Answer);
            Console.Out.WriteLine("Final question: ");
            Answer = Console.In.ReadLine();
            log.WriteLine("Finally " + Answer);
            log.Flush();
            log.Close();
        }
    }
}
