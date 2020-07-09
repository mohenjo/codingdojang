using System;
using System.Linq;

namespace CD029
{
    class Program
    {
        static void Main()
        {
            string[] input = { "a1", "a2", "a3", "a4", "a5", "b1", "b2", "b3", "b4", "b5" };

            int len = input.Length / 2;
            var result = input.Take(len).Zip(input.Skip(len), (x, y) => new string[] { x, y }).SelectMany(e => e);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
