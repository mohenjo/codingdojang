using System;
using System.Collections.Generic;
using System.Linq;

namespace CD160
{
    class Program
    {
        static int Scale = 20;

        static IEnumerable<int> Divisor = Enumerable.Range(1, Scale);

        static void Main(string[] args)
        {
            int num = Scale;
            while (!IsDividable(num)) { num += Scale; }
            Console.WriteLine(num); // 232792560
        }

        static bool IsDividable(int aNumber) => Divisor.All(element => aNumber % element == 0);
    }
}
