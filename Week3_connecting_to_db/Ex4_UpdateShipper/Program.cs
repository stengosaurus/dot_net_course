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

            // Display existing shippers
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

            // Prompt user for ShipperID to update
            Console.Write("\nEnter the ShipperID to update: ");
            if (int.TryParse(Console.ReadLine(), out int shipperId))
            {
                Console.Write("Enter new Shipper Name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter new Phone Number: ");
                string newPhone = Console.ReadLine();

                string updateQuery = "UPDATE Shippers SET ShipperName = @name, Phone = @phone WHERE ShipperID = @id";
                using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@name", newName);
                    updateCommand.Parameters.AddWithValue("@phone", newPhone);
                    updateCommand.Parameters.AddWithValue("@id", shipperId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Shipper updated successfully.");
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
