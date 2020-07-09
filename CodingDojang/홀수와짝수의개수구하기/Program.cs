using System;
using System.Collections.Generic;
using System.Linq;

namespace CD188
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> aList;
            aList = new List<int>() { 3, 4, 5, 6, 7 };
            CountOddsAndEvens(aList);
            aList = new List<int>() { 12, 16, 22, 24, 29 };
            CountOddsAndEvens(aList);
            aList = new List<int>() { 41, 43, 45, 47, 49 };
            CountOddsAndEvens(aList);
        }

        static void CountOddsAndEvens(List<int> aList)
        {
            int numEven = (from e in aList where e % 2 == 0 select e).Count();
            int numOdd = aList.Count - numEven;
            Console.WriteLine($"홀수 {numOdd}개, 짝수 {numEven}개");
        }
    }
}
