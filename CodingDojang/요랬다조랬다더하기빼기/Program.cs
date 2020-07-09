using System;
using System.Linq;

namespace CD177
{
    internal class Program
    {
        private static void Main()
        {
            int price(int p0, int t)
                => p0 + Enumerable.Range(1, t).Select(i => (i + 1) * (int)Math.Pow(-1, i + 1)).Sum();

            int initialPrice = 1000;
            int maxPrice = 0;
            int time = 0, timeAtMaxPrice = 0;
            while (true)
            {
                time++;
                var p = price(initialPrice, time);
                if (p < 0) { break; }
                if (maxPrice < p)
                {
                    maxPrice = p;
                    timeAtMaxPrice = time;
                }
            }
            Console.WriteLine(timeAtMaxPrice);
        }
    }
}