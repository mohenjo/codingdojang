using System;
using System.Linq;

namespace CD257
{
    class Program
    {
        static void Main()
        {
            int[] pool = Enumerable.Range(1, 9).ToArray(); // pool = {1, 2, ..., 9}

            for (int rpt = 0; rpt < 5; rpt++)
            {
                ShuffleArray<int>(pool); // shuffle array
                Console.WriteLine($"{{{string.Join(", ", pool)}}}");
            }
        }

        // Fisher-Yates Shuffle 알고리즘
        public static void ShuffleArray<T>(T[] anArray)
        {
            Random random = new Random(); // 시간 기준 seed

            for (int idx = 0; idx < anArray.Length; idx++)
            {
                int randomIndex = random.Next(idx, anArray.Length);
                T tempValue = anArray[randomIndex];
                anArray[randomIndex] = anArray[idx];
                anArray[idx] = tempValue;
            }
        }
    }
}
