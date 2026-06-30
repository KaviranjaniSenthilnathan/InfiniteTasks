using System;

namespace Day1
{
    public class FibonacciGenerator
    {
        public static void Run()
        {
            Console.Write("Enter number of terms: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int a = 0, b = 1;

            Console.WriteLine("Fibonacci Series:");

            for (int i = 0; i < n; i++)
            {
                Console.Write(a + " ");
                int temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}