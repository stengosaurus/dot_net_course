using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your date of birth (yyyy-MM-dd): ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime dob))
        {
            Console.WriteLine($"You were born on a {dob.DayOfWeek}");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
        }
    }
}
