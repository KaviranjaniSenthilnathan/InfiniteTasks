using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Day1 C# Programs ===");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Even/Odd Checker");
            Console.WriteLine("3. Temperature Converter");
            Console.WriteLine("4. Prime Checker");
            Console.WriteLine("5. Fibonacci Series");
            Console.WriteLine("6. Factorial");
            Console.Write("Choose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: Calculator.Run(); break;
                case 2: EvenOddChecker.Run(); break;
                case 3: TemperatureConverter.Run(); break;
                case 4: PrimeChecker.Run(); break;
                case 5: FibonacciGenerator.Run(); break;
                case 6: Factorial.Run(); break;
                default: Console.WriteLine("Invalid choice"); break;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}