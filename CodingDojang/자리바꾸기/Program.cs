using System;

namespace CD239
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine()); // 0 < number <= 10
                Console.WriteLine($"X({number}) = {Derangement(number)}");
            }
        }

        static int Derangement(int num)
        {
            if (num == 0) { return 1; }
            if (num == 1) { return 0; }
            return (num - 1) * (Derangement(num - 1) + Derangement(num - 2));
        }
    }
}
