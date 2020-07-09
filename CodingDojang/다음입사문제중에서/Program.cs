using System;
using System.Collections.Generic;
using System.Linq;

namespace CD022
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int>() { 1, 3, 4, 8, 13, 17, 20, 21 };
            GetShortestPair(input);
        }

        static void GetShortestPair(List<int> aList)
        {
            // 최소 거리 계산
            int minDistance = aList.Max();
            for (int i = 0; i < aList.Count - 1; i++)
            {
                int tmp = aList[i + 1] - aList[i];
                minDistance = minDistance < tmp ? minDistance : tmp;
            }
            // 최소 거리에 해당하는 쌍 모두 출력
            for (int i = 0; i < aList.Count - 1; i++)
            {
                int tmp = aList[i + 1] - aList[i];
                if (minDistance == tmp) { Console.WriteLine($"({aList[i]},{aList[i + 1]})"); }
            }
        }
    }
}
