using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=../Northwind.db;Version=3;";
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== Northwind Database Query Menu =====");
            Console.WriteLine("1. View Product IDs, Names, and Supplier Names");
            Console.WriteLine("2. Filter Customers by Country");
            Console.WriteLine("3. Filter Products by Price Range");
            Console.WriteLine("4. Filter Products by Category");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    DisplayProductsAndSuppliers(connectionString);
                    break;
                case "2":
                    FilterCustomersByCountry(connectionString);
                    break;
                case "3":
                    FilterProductsByPrice(connectionString);
                    break;
                case "4":
                    FilterProductsByCategory(connectionString);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Exiting... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            if (!exit)
            {
                Console.Write("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    // 1️ Join Tables: Display Product IDs, Names, and Supplier Names
    static void DisplayProductsAndSuppliers(string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT p.ProductID, p.ProductName, s.SupplierName 
                FROM Products p
                INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
                ORDER BY p.ProductID";

            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("\nProductID | Product Name | Supplier Name");
                Console.WriteLine("----------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"],-9} | {reader["ProductName"],-25} | {reader["SupplierName"]}");
                }
            }
        }
    }

    // 2️ Filter Customers by Country
    static void FilterCustomersByCountry(string connectionString)
    {
        Console.Write("\nEnter the country name: ");
        string country = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(country))
        {
            Console.WriteLine("Invalid input. Please enter a valid country.");
            return;
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT CustomerName FROM Customers
                WHERE Country = @Country
                ORDER BY CustomerName ASC";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Country", country);

                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine($"\nCustomers in {country}:");
                    Console.WriteLine("--------------------------------");

                    bool found = false;
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["CustomerName"]);
                        found = true;
                    }

                    if (!found)
                        Console.WriteLine("No customers found in this country.");
                }
            }
        }
    }

    // 3️ Filter Products by Price Range
    static void FilterProductsByPrice(string connectionString)
    {
        Console.Write("\nEnter minimum price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
        {
            Console.WriteLine("Invalid input. Enter a numeric value.");
            return;
        }

        Console.Write("Enter maximum price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
        {
            Console.WriteLine("Invalid input. Enter a numeric value.");
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
                    Console.WriteLine($"\nProducts between {minPrice:C} and {maxPrice:C}:");
                    Console.WriteLine("-----------------------------------------------");

                    bool found = false;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProductName"],-30} | {reader["Price"]:C}");
                        found = true;
                    }

                    if (!found)
                        Console.WriteLine("No products found in this price range.");
                }
            }
        }
    }

    // 4️ Filter Products by Category
    static void FilterProductsByCategory(string connectionString)
    {
        Console.Write("\nEnter the category name: ");
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
