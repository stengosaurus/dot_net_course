using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter temperature in Celsius: ");
        if (double.TryParse(Console.ReadLine(), out double tempC))
        {
            double tempF = 1.8 * tempC + 32;
            Console.WriteLine($"Temperature in Fahrenheit: {tempF}°F");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
