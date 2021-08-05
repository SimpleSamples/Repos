using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// string.Format for a number
// https://social.msdn.microsoft.com/Forums/vstudio/en-US/2632b390-026a-4a16-8a79-fb91bc292bb3/stringformat-for-a-number?forum=csharpgeneral

namespace CustomFormatNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int i1 = 12345;
            int i2 = 1234;
            int i3 = 123;
            int i4 = 123456;
            int i5 = 1234567;
            //Console.WriteLine(123.ToString("# ### ### ###").TrimStart('0'));
            //Console.WriteLine(i5.ToString("# ### ### ###").TrimStart(trimChars));
            //Console.WriteLine(fmt, Int32.MaxValue);
            Console.WriteLine('R' + string.Format("{0:# ### ### ###}", Int32.MaxValue).TrimStart());
            Console.WriteLine(Mine(i1));
            Console.WriteLine(Mine(i2));
            Console.WriteLine(Mine(i3));
            Console.WriteLine(Mine(i4));
            Console.WriteLine(Mine(i5));
            //AnteMeridian();
        }

        private static string Mine(int i)
        {
            char[] trimChars = new char[] { '0', ' ' };
            string fmt = "{0:# ### ### ###}";
            return 'R' + string.Format(fmt, i).TrimStart();
        }

        private static void AnteMeridian()
        {
            int i1 = 12345;
            int i2 = 1234;
            int i3 = 123;
            int i4 = 123456;
            int i5 = 1234567;
            Console.WriteLine(Format(i1));
            Console.WriteLine(Format(i2));
            Console.WriteLine(Format(i3));
            Console.WriteLine(Format(i4));
            Console.WriteLine(Format(i5));
        }

        static string Format(int i)
        {
            return "R" + string.Format("{0:# ###}", i).Trim();
        }
    }
}
