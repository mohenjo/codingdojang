using System;
using System.Collections.Generic;
using System.Linq;

namespace CD052
{
    class Program
    {
        static void Main()
        {
            int[] inputSpec = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
            int arrayLength = inputSpec[0];
            int windowLength = inputSpec[1];

            List<int> inputList = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();

            DisplaySlidingMinMax(windowLength, inputList);
        }

        static void DisplaySlidingMinMax(int windowLength, List<int> inputArray)
        {
            Queue<int> window = new Queue<int>(inputArray.Take(windowLength - 1));
            List<int> maxValues = new List<int>();
            List<int> minValues = new List<int>();
            // sliding window 큐에 새로운 입력 배열의 다음 항목 enqueue, 기존 항목 dequeue
            // 최대, 최소값 확인
            for (int idx = windowLength - 1; idx < inputArray.Count; idx++)
            {
                window.Enqueue(inputArray[idx]);
                if (window.Count > windowLength) { _ = window.Dequeue(); }
                maxValues.Add(window.Max());
                minValues.Add(window.Min());
            }

            Console.WriteLine(string.Join(" ", minValues));
            Console.WriteLine(string.Join(" ", maxValues));
        }
    }
}
