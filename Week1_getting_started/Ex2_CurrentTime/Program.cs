using System;

class Program
{
    static void Main()
    {
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"Current Time: {currentTime}");
    }
}
