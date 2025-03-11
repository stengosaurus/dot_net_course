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

            Console.Write("Enter Shipper Name: ");
            string shipperName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            string query = "INSERT INTO Shippers (ShipperName, Phone) VALUES (@name, @phone)";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", shipperName);
                command.Parameters.AddWithValue("@phone", phone);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("✅ Shipper added successfully!");
                }
                else
                {
                    Console.WriteLine("❌ Error: Shipper could not be added.");
                }
            }
        }
    }
}
