using System;

namespace Day1
{
    public class Factorial
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            long result = CalculateFactorial(num);

            Console.WriteLine($"Factorial: {result}");
        }

        private static long CalculateFactorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            return n * CalculateFactorial(n - 1);
        }
    }
}