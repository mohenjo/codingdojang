using System;
using System.Linq;

namespace CD028
{
    class Program
    {
        static void Main()
        {
            int[] input = { -1, 1, 3, -2, 2 };

            int[] result = input.Where(e => e <= 0).Concat(input.Where(e => e > 0)).ToArray();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
