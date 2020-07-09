using System;

namespace CD247
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(GetSuffix(i));
            }
        }

        static string GetSuffix(int number)
        {
            string suffix = string.Empty;
            switch (number)
            {
                case int n when n % 10 == 1 && n % 100 != 11:
                    suffix = "st";
                    break;
                case int n when n % 10 == 2 && n % 100 != 12:
                    suffix = "nd";
                    break;
                case int n when n % 10 == 3 && n % 100 != 13:
                    suffix = "rd";
                    break;
                default:
                    suffix = "th";
                    break;
            }
            return $"{number}{suffix}";
        }
    }
}
