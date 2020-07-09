using System;
using System.Linq;

namespace CD210
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int result = (from chr in input.ToCharArray()
                          select (int)char.GetNumericValue(chr)).Sum();
            Console.WriteLine(result);
        }
    }
}
