using RestSharp;
using System;
using System.IO;

namespace Snapshot
{
    class Program
    {
        static string outfilename = @"G:\Sam\Documents\Source\Repos\Snapshot\Snapshot.xml";

        static void Main(string[] args)
        {
            IRestResponse response = null;
            try
            {
                Console.Write("Enter city: ");
                string incity = Console.ReadLine();
                string city = System.Uri.EscapeDataString(incity);
                string query = $"cityname={city}&minLotSize1=10&maxLotSize1=900&propertytype=MOBILE%20HOME&orderby=saleamt";
                var client = new RestClient("https://api.gateway.attomdata.com/propertyapi/v1.0.0/property/snapshot?" + query);
                var request = new RestRequest(Method.GET);
                request.AddHeader("apikey", "a6c28f4e79ed1371e6a6b6facd30a5bd");
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting data: {ex.Message}");
                return;
            }
            Console.WriteLine($"Content length: {response.ContentLength}");
            try
            {
                StreamWriter sw = new StreamWriter(outfilename);
                sw.Write(response.Content);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing data: {ex.Message}");
                return;
            }
        }
    }
}
