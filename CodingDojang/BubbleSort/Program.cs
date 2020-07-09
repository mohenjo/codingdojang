using System;
using System.Collections.Generic;
using System.Linq;

namespace CD061
{
    class Program
    {
        static void Main()
        {
            int arraySize = int.Parse(Console.ReadLine());
            int[] inputArray = new int[arraySize];
            inputArray = Console.ReadLine().Split(' ').Select((s) => int.Parse(s)).ToArray();

            BubbleSort anInput = new BubbleSort(inputArray.ToList());

            List<int> result = anInput.GetBubbleSortedList(out int loopCount, out int swapCount);

            Console.WriteLine($"{loopCount} {swapCount}");
            Console.WriteLine(string.Join(" ", result));

            Console.ReadKey();
        }
    }

    class BubbleSort
    {
        public List<int> SourceList = new List<int>();

        public List<int> BubbleSortedList = new List<int>();

        public BubbleSort(List<int> inputList)
        {
            SourceList = inputList;
            BubbleSortedList = inputList;
        }

        // 버블 정렬 실행
        public List<int> GetBubbleSortedList(out int loopCount, out int swapCount)
        {
            bool swapped = true; // 한 루프 내에서 swap이 발생하였는지 여부
            swapCount = 0;
            loopCount = 0;
            while (swapped)
            {
                swapped = false;
                for (int idx = 0; idx < SourceList.Count - 1; idx++)
                {
                    if (!IsSorted(idx))
                    {
                        Swap(idx);
                        swapped = true;
                        swapCount++;
                    }
                }
                loopCount++;
            }
            return BubbleSortedList;
        }

        // 특정 인덱스, 인덱스 + 1 관계가 정렬돼 있는지 확인
        private bool IsSorted(int idx)
            => BubbleSortedList[idx] <= BubbleSortedList[idx + 1] ? true : false;


        // 특정 인덱스, 인덱스 +1 의 값을 교환
        private void Swap(int idx)
        {
            int tmpVal = BubbleSortedList[idx];
            BubbleSortedList[idx] = BubbleSortedList[idx + 1];
            BubbleSortedList[idx + 1] = tmpVal;
        }
    }
}
