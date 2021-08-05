using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsRuntimeComponent1;

namespace csConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            /*
            string s = "something";
            try
            {
                XmlSerializer sr = new XmlSerializer(s.GetType());
                TextWriter writer = new StreamWriter("csConsole.txt");
                sr.Serialize(writer, s);
                writer.Close(); Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            string userName = "something";
            char[] nameArray = new char[userName.Length];
            for (var i = userName.Length; i > 0; i--)
            {
                nameArray[userName.Length - i] = userName[i - 1];
            }
            Console.WriteLine("Reversed name: " + new string(nameArray));
            string age = Console.ReadLine();
            int intage;
            if (int.TryParse(age, out intage))
            {
                if (intage > 18)
                    Console.WriteLine("Over 18");
                else
                    Console.WriteLine("17 or under");
            }
            else
                Console.WriteLine("Invalid response");
            string strNumber = "zł123.456!78";
            NumberFormatInfo formatInfo = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatInfo.CurrencyGroupSeparator = ".";
            formatInfo.CurrencySymbol = "zł";
            formatInfo.CurrencyDecimalSeparator = "!";
            formatInfo.CurrencyGroupSeparator = ".";
            formatInfo.CurrencyGroupSizes = new int[1] { 3 };
            //
            formatInfo.NumberDecimalSeparator = ",";
            //
            const NumberStyles styles = NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            decimal out_number3 = Decimal.Parse(strNumber, styles, formatInfo);
            Console.WriteLine(strNumber);
            Console.WriteLine(out_number3);
            Console.WriteLine(out_number3.ToString("C", formatInfo));
            */
            string s = Console.ReadLine();
            while (s.Length > 0)
            {
                Console.WriteLine(s.All(Char.IsDigit) ? "Yes" : "No");
                s = Console.ReadLine();
            }
        }
    }
}
