using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealtimeRedirectionTest
{
    class Program
    {
        static readonly string[] Days = new [] {"Monday", "Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday", "Sunday"};
        static int lastlength = 0;
        static int pos = 0;

        static void Main(string[] args)
        {
            Console.Write("Status: ");
            pos = Console.CursorLeft;
            foreach (string Day in Days)
            {
                Update(Day);
            }
            Console.WriteLine("\r\nDone");
        }

        private static void Update(string day)
        {
            lastlength = Console.CursorLeft - pos;
            Console.Write(new string((char)8, lastlength));
            Console.Write(day.PadRight(lastlength));
            Thread.Sleep(1000);
        }
    }
}
