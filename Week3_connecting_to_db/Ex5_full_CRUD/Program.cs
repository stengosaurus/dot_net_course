using System;
using System.Data.SQLite;

class Program
{
    static string connectionString = "Data Source=../Northwind.db;Version=3;";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Shippers Management System");
            Console.WriteLine("==========================");
            Console.WriteLine("1. View All Shippers");
            Console.WriteLine("2. Add a New Shipper");
            Console.WriteLine("3. Update a Shipper");
            Console.WriteLine("4. Delete a Shipper");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewShippers();
                    break;
                case "2":
                    AddShipper();
                    break;
                case "3":
                    UpdateShipper();
                    break;
                case "4":
                    DeleteShipper();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ViewShippers()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("\nExisting Shippers:");
            string query = "SELECT * FROM Shippers";
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("\nID | Shipper Name | Phone");
                Console.WriteLine("-----------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ShipperID"]} | {reader["ShipperName"]} | {reader["Phone"]}");
                }
            }
        }
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    static void AddShipper()
    {
        Console.Write("\nEnter Shipper Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Shippers (ShipperName, Phone) VALUES (@name, @phone)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("\nShipper added successfully!");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    static void UpdateShipper()
    {
        Console.Write("\nEnter the ShipperID to update: ");
        if (int.TryParse(Console.ReadLine(), out int shipperId))
        {
            Console.Write("Enter new Shipper Name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Phone Number: ");
            string newPhone = Console.ReadLine();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Shippers SET ShipperName = @name, Phone = @phone WHERE ShipperID = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", newName);
                    command.Parameters.AddWithValue("@phone", newPhone);
                    command.Parameters.AddWithValue("@id", shipperId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("\nShipper updated successfully!");
                    else
                        Console.WriteLine("\nNo Shipper found with that ID.");
                }
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input. Please enter a valid ShipperID.");
        }

        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    static void DeleteShipper()
    {
        Console.Write("\nEnter the ShipperID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int shipperId))
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Shippers WHERE ShipperID = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", shipperId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("\nShipper deleted successfully!");
                    else
                        Console.WriteLine("\nNo Shipper found with that ID.");
                }
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input. Please enter a valid ShipperID.");
        }

        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
