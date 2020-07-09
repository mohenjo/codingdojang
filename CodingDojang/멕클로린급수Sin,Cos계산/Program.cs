using System;
using System.Numerics;

namespace CD225
{
    internal class Program
    {
        private static void Main()
        {
            MaclaurinSeries testCase = new MaclaurinSeries(3.141592, 20);
            Console.WriteLine(testCase.Sin());
            Console.WriteLine(testCase.Cos());
            Console.WriteLine(testCase.Tan());
        }
    }

    public class MaclaurinSeries
    {
        private readonly double Radian;

        private readonly BigInteger MaxIndex;

        public MaclaurinSeries(double radian, BigInteger maxIndex)
        {
            Radian = radian;
            MaxIndex = maxIndex;
        }

        public double Sin()
        {
            double sum = 0;
            for (BigInteger n = 0; n <= MaxIndex; n++)
            {
                sum += Math.Pow(-1.0, (double)n) / (double)GetFactorial(2 * n + 1)
                    * Math.Pow(Radian, (double)(2 * n + 1));
            }
            return sum;
        }

        public double Cos()
        {
            double sum = 0;
            for (BigInteger n = 0; n <= MaxIndex; n++)
            {
                sum += Math.Pow(-1.0, (double)n) / (double)GetFactorial(2 * n)
                    * Math.Pow(Radian, (double)(2 * n));
            }
            return sum;
        }

        public double Tan()
        {
            return Sin() / Cos();
        }

        private static BigInteger GetFactorial(BigInteger n)
        {
            if (n == 0) { return 1; }
            else { return n * GetFactorial(n - 1); }
        }
    }
}
