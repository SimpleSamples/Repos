using Microsoft.Data.Sqlite;
using System;

namespace ConsoleWithSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            SqliteConnection MyDataConnection = new SqliteConnection("Data Source=G:\\Sam\\Documents\\Miscelaneous.db");
            if (MyDataConnection == null)
            {
                Console.WriteLine("Null");
                return;
            }
            Console.WriteLine("Not null");
            try { MyDataConnection.Open(); }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
            Console.WriteLine("Opened");
        }
    }
}
