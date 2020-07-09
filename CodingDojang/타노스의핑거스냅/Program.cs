using System;
using System.Collections.Generic;

namespace CD168
{
    class Program
    {
        static void Main()
        {
            List<int> alist = new List<int>() { 2, 3, 1, 6, 5, 7 };
            Console.WriteLine(String.Join(",", FlipFingers(alist)));
        }

        static Random rnd = new Random();

        static List<T> FlipFingers<T>(List<T> aList) 
        {
            // Shuffle Generic List
            List<T> sourceList = new List<T>(aList);
            List<T> newList = new List<T>();
            while (sourceList.Count > 0)
            {
                int idx = rnd.Next(0, sourceList.Count);
                newList.Add(sourceList[idx]); sourceList.RemoveAt(idx);
            }
            // flip fingers
            int len = newList.Count;
            int halfIdx = len % 2 == 0 ? len / 2 : len / 2 + rnd.Next(0, 2);
            return newList.GetRange(0, halfIdx);
        }
    }
}
