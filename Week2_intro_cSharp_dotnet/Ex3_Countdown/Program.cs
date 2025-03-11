using System;
using System.Threading;

class Program
{
    static void Main()
    {
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine("Time's up!");
    }
}
