using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.IO;

namespace ConsoleWhoIs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetWhoisInformation("whois.iana.org", "bing.com"));
        }

        // c# - How to get whois information of a domain name in my program? - Stack Overflow
        // https://stackoverflow.com/questions/53623/how-to-get-whois-information-of-a-domain-name-in-my-program

        /// <summary>
        /// Gets the whois information.
        /// </summary>
        /// <param name="whoisServer">The whois server.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        static private string GetWhoisInformation(string whoisServer, string url)
        {
            // send query
            StringBuilder stringBuilderResult = new StringBuilder();
            TcpClient tcpClinetWhois = new TcpClient(whoisServer, 43);
            NetworkStream networkStreamWhois = tcpClinetWhois.GetStream();
            BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois);
            StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois);
            streamWriter.WriteLine(url);
            streamWriter.Flush();

            // receive results
            StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois);
            while (!streamReaderReceive.EndOfStream)
                stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());

            return stringBuilderResult.ToString();
        }
    }
}
