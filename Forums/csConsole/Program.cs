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
            Console.WriteLine(getDay(2));
        }

        static string getDay(int dayNum)
        {
            string dayName;

            switch (dayNum)
            {
                case 0: dayName = "Monday"; break;
                case 1: dayName = "Tuesday"; break;
                case 2: dayName = "Wednesday"; break;
                case 3: dayName = "Thursday"; break;
                case 4: dayName = "Friday"; break;
                case 5: dayName = "Saturday"; break;
                case 6: dayName = "Sunday"; break;
                default: dayName = "Invalid"; break;
            }

            return dayName;
        }
    }
}
