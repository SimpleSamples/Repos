using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class Class1
    {

        public static void ShowValue(int value)
        {
            Console.WriteLine($"Value is: {value}");
        }

        public static void GetOrder(out string input)
        {
            input = "[ORDER_RES]|2424245|0793|1000|2421Ad";
        }

        public static bool SendResult(int pos, string serial)
        {
            Console.WriteLine($"Sent {serial} at {pos}");
            return true;
        }
    }
}
