using System;

namespace Day1
{
    public class TemperatureConverter
    {
        public static void Run()
        {
            Console.Write("Enter temperature in Celsius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());

            double fahrenheit = (celsius * 9 / 5) + 32;

            Console.WriteLine($"Fahrenheit: {fahrenheit}");
        }
    }
}
