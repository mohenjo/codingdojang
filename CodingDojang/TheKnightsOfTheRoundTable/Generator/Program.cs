using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\Temp\CD055Input.txt";

            List<string> saveText = new List<string>();
            for (int repeat = 0; repeat < 1000; repeat++)
            {
                saveText.Add(Generate());
            }
            File.WriteAllLines(path, saveText);
            Console.WriteLine($"Input file for CD055 is generated at {path}");

        }
        static Random rnd = new Random();

        static string Generate()
        {
            double[] sides = new double[3];
            do
            {
                for (int r = 0; r < 3; r++)
                {
                    double gen = 0.0;
                    while (gen <= 0)
                    {
                        gen = Math.Round(rnd.NextDouble() * 1000000, 1);
                    }
                    sides[r] = gen;
                }
            } while (sides.Max() > sides.Sum() / 2);

            if (sides.Max() > sides.Sum() / 2) Console.WriteLine("Error!");

            return String.Join(",", sides);
        }
    }
}
