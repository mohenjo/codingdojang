using System;
using System.Linq;

namespace CD041
{
    class Program
    {
        static void Main()
        {
            string input = "a1b2cde3~g45hi6";
            string result = new String(input.Select((v, i) => (i % 2 == 1 && Char.IsDigit(v)) ? '*' : v).ToArray());
            Console.WriteLine(result);
        }
    }
}