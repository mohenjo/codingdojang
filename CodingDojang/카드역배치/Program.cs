using System;
using System.Collections.Generic;
using System.Linq;

namespace CD091
{
    class Program
    {
        static void Main()
        {
            List<int> cards = Enumerable.Range(1, 20).ToList();
            for (int rpt = 1; rpt <= 10; rpt++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int idx = input[0] - 1;
                int count = input[1] - input[0] + 1;
                cards.Reverse(idx, count);
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
