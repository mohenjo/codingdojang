using System;
using System.Linq;
using System.IO;

namespace CD055
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines(@"C:\Temp\CD055Input.txt");
            foreach (var input in inputs)
            {
                ParseInput(input, out double a, out double b, out double c);
                Console.WriteLine($"The radius of the round table is: {Radius(a, b, c)}");
            }
        }

        static double Radius(double a, double b, double c)
        {
            double s = (a + b + c) / 2;
            return Math.Round((Math.Sqrt(s * (s - a) * (s - b) * (s - c)) / s), 3);
        }

        static void ParseInput(string aString, out double a, out double b, out double c)
        {
            double[] parsedData = aString.Split(',').Select(s => double.Parse(s)).ToArray();
            a = parsedData[0]; b = parsedData[1]; c = parsedData[2];
        }
    }
}
