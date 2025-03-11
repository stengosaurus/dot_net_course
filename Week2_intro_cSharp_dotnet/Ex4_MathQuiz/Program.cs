using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int num1 = rand.Next(1, 10);
        int num2 = rand.Next(1, 10);
        int correctAnswer = num1 + num2;

        Console.WriteLine($"Solve: {num1} + {num2} = ?");
        int userAnswer;

        do
        {
            Console.Write("Enter your answer: ");
            if (int.TryParse(Console.ReadLine(), out userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct! Well done.");
                }
                else
                {
                    Console.WriteLine("Incorrect. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        while (userAnswer != correctAnswer);
    }
}
