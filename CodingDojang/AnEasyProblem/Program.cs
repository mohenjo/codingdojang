using System;
using System.Linq;

namespace CD048
{
    class Program
    {
        static void Main()
        {
            string result = String.Empty;
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0) { break; }
                result += NextValue(input).ToString() + Environment.NewLine;
            }
            Console.WriteLine(result);
        }

        static int NextValue(int aNumber)
        {
            int oneCount = CountOne(aNumber);
            while (oneCount != CountOne(++aNumber)) { }
            return aNumber;
        }

        static int CountOne(int aNumber) => Convert.ToString(aNumber, 2).Count(b => b == '1');
    }
}
