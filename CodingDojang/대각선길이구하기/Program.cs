using System;

namespace CD240
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetDiagonalLength(3.0, 4.0));
        }

        static double GetDiagonalLength(double x, double y) => Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0));
    }
}
