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

            // Display available shippers
            Console.WriteLine("Existing Shippers:");
            string selectQuery = "SELECT * FROM Shippers";
            using (var selectCommand = new SQLiteCommand(selectQuery, connection))
            using (var reader = selectCommand.ExecuteReader())
            {
                Console.WriteLine("ID | Shipper Name | Phone");
                Console.WriteLine("-----------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ShipperID"]} | {reader["ShipperName"]} | {reader["Phone"]}");
                }
            }

            // Prompt user for ShipperID to delete
            Console.Write("\nEnter the ShipperID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int shipperId))
            {
                string deleteQuery = "DELETE FROM Shippers WHERE ShipperID = @id";
                using (var deleteCommand = new SQLiteCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@id", shipperId);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Shipper deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Shipper found with that ID.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ShipperID.");
            }
        }
    }
}
