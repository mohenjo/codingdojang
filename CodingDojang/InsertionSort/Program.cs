using System;
using System.Collections.Generic;
using System.Linq;

namespace CD056
{
    class Program
    {
        static void Main()
        {
            SortMethod srt = new SortMethod(new List<int>() { 5, 2, 4, 6, 1, 3 });

            string result = string.Join(", ", srt.DoInsertionSort());
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

    class SortMethod
    {
        private List<int> SourceList = new List<int>();

        private List<int> InsertionSortedList = new List<int>();

        public SortMethod(List<int> aList)
        {
            SourceList = aList;
            InsertionSortedList = aList;
        }

        // Insertion Sort 실행
        public List<int> DoInsertionSort()
        {
            // 각 인덱스의 값 및 좌측부분 리스트에 대해 삽입 정렬 ... (1)
            // (1) + 각 인덱스의 우측 부분 리스트 = 해당 인덱스까지 정렬된 리스트 ... (2)
            // (2)에 대해 계속해서 마지막 인덱스까지 상기 과정 반복
            for (int idx = 1; idx < SourceList.Count; idx++)
            {
                // 현재 인덱스의 좌측부 리스트 및 해당 인덱스의 값으로 삽입 정렬
                List<int> sortedPart = InsertValue(InsertionSortedList.GetRange(0, idx), SourceList[idx]);
                // 현재 인덱스의 우측부 리스트
                List<int> unsortedPart = SourceList.GetRange(idx + 1, SourceList.Count - (idx + 1));
                // 현재 인덱스에 대해 정렬된 좌측부 리스트 + 우측부 리스트
                InsertionSortedList = sortedPart.Concat(unsortedPart).ToList(); ;
            }
            return InsertionSortedList;
        }

        // 리스트(aList)와 값(aValue)가 주어졌을 때, 오름차순으로 aValue가 삽입된 리스트 반환
        private static List<int> InsertValue(List<int> aList, int aValue)
        {
            // aValue의 삽입 위치 계산
            int insertIdx = aList.Count; // 삽입 인덱스
            for (int idx = 0; idx < aList.Count; idx++)
            {
                if (aValue <= aList[idx])
                {
                    insertIdx = idx;
                    break;
                }
            }
            // 해당 위치에 aValue 삽입된 리스트 반환
            List<int> resultList = new List<int>();
            resultList.AddRange(aList.GetRange(0, insertIdx));
            resultList.Add(aValue);
            resultList.AddRange(aList.GetRange(insertIdx, aList.Count - insertIdx));
            return resultList;
        }
    }
}
