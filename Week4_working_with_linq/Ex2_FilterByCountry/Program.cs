using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=../Northwind.db;Version=3;";

        Console.Write("Enter a country: ");
        string country = Console.ReadLine();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT CustomerName 
                FROM Customers 
                WHERE Country = @Country 
                ORDER BY CustomerName ASC";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Country", country);

                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nCustomer Names:");
                    Console.WriteLine("-----------------");

                    bool found = false;
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["CustomerName"]);
                        found = true;
                    }

                    if (!found)
                    {
                        Console.WriteLine("No customers found in this country.");
                    }
                }
            }
        }
    }
}
