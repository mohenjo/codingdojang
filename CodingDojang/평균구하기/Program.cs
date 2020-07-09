using System;
using System.Collections.Generic;

namespace CD185
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> checkList;

            checkList = new List<int>() { 4, 6, 8 };
            Console.WriteLine(GetListAverage(checkList));
            checkList = new List<int>() { 11, 17, 20, 24 };
            Console.WriteLine(GetListAverage(checkList));
            checkList = new List<int>() { 26, 33, 45, 51, 60 };
            Console.WriteLine(GetListAverage(checkList));
        }

        static double GetListAverage(List<int> aList)
        {
            int sum = 0;
            foreach (var e in aList) { sum += e; }
            return sum / aList.Count;
        }
    }
}
