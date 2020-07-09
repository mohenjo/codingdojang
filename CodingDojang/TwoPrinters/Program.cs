using System;
using System.Linq;
using System.Text;

namespace CD062
{
    class Program
    {
        static void Main()
        {
            int numCases = int.Parse(Console.ReadLine());
            var result = new StringBuilder();
            for (int i = 0; i < numCases; i++)
            {
                var inputs = Console.ReadLine().Split(' ').Select(s=>int.Parse(s)).ToArray();
                int X = inputs[0];
                int Y = inputs[1];
                int N = inputs[2];
                result.Append($"{GetPrintTime(X, Y, N)} ");
            }
            Console.WriteLine(result);
        }

        static int GetPrintTime(int X, int Y, int N)
        {
            int ai = N * Y / (X + Y);
            int bi = N * X / (X + Y);
            int Nr = N - (ai + bi);

            return Math.Max(ai * X, bi * Y) + Nr * Math.Min(X, Y);
        }
    }
}
