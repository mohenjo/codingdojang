using System;

namespace CD044
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetMinOnesLength(3));
            Console.WriteLine(GetMinOnesLength(7));
            Console.WriteLine(GetMinOnesLength(9901));
        }

        static int GetMinOnesLength(int aNumber)
        {
            string ones = "1";
            while (long.Parse(ones) % aNumber != 0) { ones += "1"; }
            return ones.Length;
        }
    }
}
