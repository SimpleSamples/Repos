using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// how can console to windows forms
// https://social.msdn.microsoft.com/Forums/en-US/fab6a4fe-0f24-4a89-b598-b9f01af1a0b6/how-can-console-to-windows-forms?forum=csharpgeneral

// Karen is correct that the functions are, as shown, extension methods

namespace ConsoleToForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public decimal GetMedian(this IEnumerable<int> source)
        {
            // Create a copy of the input, and sort the copy
            int[] temp = source.ToArray();
            Array.Sort(temp);
            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }

        public int GetMode(this IEnumerable<int> list)
        {
            // Initialize the return value
            int mode = default(int);
            // Test for a null reference and an empty list
            if (list != null && list.Count() > 0)
            {
                // Store the number of occurences for each element
                Dictionary<int, int> counts = new Dictionary<int, int>();
                // Add one to the count for the occurence of a character
                foreach (int element in list)
                {
                    if (counts.ContainsKey(element))
                        counts[element]++;
                    else
                        counts.Add(element, 1);
                }
                // Loop through the counts of each element and find the 
                // element that occurred most often
                int max = 0;
                foreach (KeyValuePair<int, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        // Update the mode
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }
            return mode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<int> source = new List<int>() { 10, 23 };
            var result = source.GetMedian(source);
        }
    }
}
