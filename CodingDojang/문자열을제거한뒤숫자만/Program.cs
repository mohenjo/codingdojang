using System;

namespace CD174
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(RemoveStrings(input));
        }

        static string RemoveStrings(string input)
        {
            string result = String.Empty;
            foreach (var val in input)
            {
                if (Char.IsDigit(val)) { result += val.ToString(); }
            }
            return result;
        }
    }
}
