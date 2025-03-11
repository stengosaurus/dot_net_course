using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
    string connectionString = "Data Source=../Northwind.db;Version=3;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Shippers";

            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("ID | Shipper Name | Phone");
                Console.WriteLine("-----------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ShipperID"]} | {reader["ShipperName"]} | {reader["Phone"]}");
                }
            }
        }
    }
}
