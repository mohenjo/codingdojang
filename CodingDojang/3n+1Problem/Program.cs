using System;

namespace CD023
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input range (min max): ");
            string[] input = Console.ReadLine().Split();
            int min = int.Parse(input[0]);
            int max = int.Parse(input[1]);
            int result = GetMaxCycleLen(min, max);
            Console.WriteLine($"{min} {max} {result}");
        }

        static int GetCycleLen(int aNumber) // 수열 길이 반환
        {
            int count = 1;
            while (aNumber != 1)
            {
                if (aNumber % 2 == 0) { aNumber /= 2; }
                else { aNumber = 3 * aNumber + 1; }
                count++;
            }
            return count;
        }

        static int GetMaxCycleLen(int beginNumber, int endNumber) // 범위 내 최대 수열 길이 반환
        {
            int maxLen = 0;
            for (int i = beginNumber; i <= endNumber; i++)
            {
                int tmp = GetCycleLen(i);
                maxLen = tmp > maxLen ? tmp : maxLen;
            }
            return maxLen;
        }
    }
}
