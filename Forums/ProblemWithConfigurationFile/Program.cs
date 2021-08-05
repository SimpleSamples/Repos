using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

// Problem with configuration file - Microsoft Q&A
// https://docs.microsoft.com/en-us/answers/questions/436916/problem-with-configuration-file.html

namespace ProblemWithConfigurationFile
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            try
            {
                using (conn)
                {
                    // Try to open the connection.
                    conn.Open();
                    Console.WriteLine("Server Version: " + conn.ServerVersion);

                }
            }
            catch (Exception err)
            {
                // Handle an error by displaying the information.
                Console.WriteLine("Error reading the database. ");
                Console.WriteLine(err.Message);
            }
            conn.Close();
            Console.WriteLine("Now Connection Is:" + conn.State.ToString());
        }
    }
}
