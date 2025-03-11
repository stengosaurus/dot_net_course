using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=../Northwind.db;Version=3;";

        Console.Write("Enter the minimum price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            return;
        }

        Console.Write("Enter the maximum price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            return;
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT ProductName, Price 
                FROM Products 
                WHERE Price BETWEEN @MinPrice AND @MaxPrice 
                ORDER BY Price ASC";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);

                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nProducts within the price range:");
                    Console.WriteLine("---------------------------------");

                    bool found = false;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProductName"]} - ${reader["Price"]}");
                        found = true;
                    }

                    if (!found)
                    {
                        Console.WriteLine("No products found in this price range.");
                    }
                }
            }
        }
    }
}
