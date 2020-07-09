using System;
using System.Collections.Generic;

namespace CD167
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<double>() { 2, 6, 4, 7 };
            MultiplyExceptMe(input);
        }

        static void MultiplyExceptMe(List<double> aList)
        {
            var result = new List<double>();
            for (int idx = 0; idx < aList.Count; idx++)
            {
                var newList = new List<double>(aList); newList.RemoveAt(idx);
                result.Add(MultiplyList(newList));
                Console.Write($"{result[idx]} ");
            }
            Console.WriteLine();

        }
        static double MultiplyList(List<double> aList)
        {
            double result = 1;
            aList.ForEach(element => result *= element);
            return result;
        }
    }
}
