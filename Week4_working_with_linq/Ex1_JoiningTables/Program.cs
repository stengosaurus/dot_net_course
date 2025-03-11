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

            string query = @"
                SELECT Products.ProductID, Products.ProductName, Suppliers.SupplierName
                FROM Products
                JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID";

            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("ProductID | Product Name | Supplier Name");
                Console.WriteLine("---------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"],-9} | {reader["ProductName"],-30} | {reader["SupplierName"]}");
                }
            }
        }
    }
}
