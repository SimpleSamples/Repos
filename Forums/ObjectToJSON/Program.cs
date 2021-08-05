using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// C# object to JSON string
// https://docs.microsoft.com/en-us/answers/questions/370071/c-object-to-json-string.html

namespace ObjectToJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Item i1 = new Item
            {
                Name = "test1",
                Value = "result1"
            };

            Item i2 = new Item
            {
                Name = "test2",
                Value = "result2"
            };

            ReturnData returnData = new ReturnData();

            List<Item> items = new List<Item>();

            items.Add(i1);
            items.Add(i2);

            returnData.Type = "type1";
            returnData.Items = items;

            var json = JsonConvert.SerializeObject(returnData);
            Console.WriteLine(json);
        }
    }

    class ReturnData
    {
        public string Type { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
