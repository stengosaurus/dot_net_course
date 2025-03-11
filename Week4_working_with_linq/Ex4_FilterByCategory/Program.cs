using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=../Northwind.db;Version=3;";

        Console.Write("Enter the category name: ");
        string categoryName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(categoryName))
        {
            Console.WriteLine("Invalid input. Please enter a valid category name.");
            return;
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT p.ProductName
                FROM Products p
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE c.CategoryName = @CategoryName
                ORDER BY p.ProductName ASC";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine($"\nProducts in the '{categoryName}' category:");
                    Console.WriteLine("---------------------------------------------");

                    bool found = false;
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["ProductName"]);
                        found = true;
                    }

                    if (!found)
                    {
                        Console.WriteLine("No products found under this category.");
                    }
                }
            }
        }
    }
}
