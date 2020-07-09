using System;
using System.Collections.Generic;

namespace CD186
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> alist;
            alist = new List<int>() { 7, 9, 14 };
            Console.WriteLine(GetMedian(alist));
            alist = new List<int>() { 24, 31, 35, 49 };
            Console.WriteLine(GetMedian(alist));
            alist = new List<int>() { 17, 37, 37, 47, 57 };
            Console.WriteLine(GetMedian(alist));
        }

        static double GetMedian(List<int> aList)
        {
            aList.Sort();
            double median;
            int listLength = aList.Count;
            if (listLength % 2 == 0)
            {
                median = (aList[listLength / 2 - 1] + aList[listLength / 2]) / 2;
            }
            else
            {
                median = aList[(int)(listLength / 2)];
            }
            return median;
        }
    }
}
