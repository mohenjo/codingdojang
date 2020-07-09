using System;
using System.Collections.Generic;
using System.Linq;

namespace CD250
{
    class Program
    {
        static void Main()
        {
            List<int> primeNumbers = Utils.GetPrimeNumbers(1_000, 9_999); // 소수 리스트
            // 소수 리스트 내에서 (1) 등차 수열이 구성되고 (2) 순열관계를 만족하는지 검사
            for (int idx = 1; idx < primeNumbers.Count - 1; idx++)
            {
                int middleValue = primeNumbers[idx];
                for (int smallerIdx = 0; smallerIdx < idx; smallerIdx++)
                {
                    int leftValue = primeNumbers[smallerIdx];
                    int diff = middleValue - leftValue;
                    int rightValue = middleValue + diff;

                    if (primeNumbers.Contains(rightValue) && Utils.IsPermutated(leftValue, middleValue, rightValue))
                    {
                        string result = $"{leftValue}{middleValue}{rightValue}";
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }

    class Utils
    {
        // 특정 범위의 소수 리스트를 반환
        public static List<int> GetPrimeNumbers(int lowerLimit, int upperLimit)
        {
            List<int> primeNumbers = new List<int> { 2 };
            for (int checkVal = 3; checkVal <= upperLimit; checkVal++)
            {
                if (primeNumbers.All(i => checkVal % i != 0))
                {
                    primeNumbers.Add(checkVal);
                }
            }
            return primeNumbers.Where(i => i >= lowerLimit).Select(i => i).ToList();
        }

        // 세 정수가 순열관계인지 확인
        public static bool IsPermutated(int lVal, int mVal, int rVal)
        {
            Func<int, string> sortedStr = (i) => new string(i.ToString().OrderBy(e => e).ToArray());
            string lValSorted = sortedStr(lVal);
            string mValSorted = sortedStr(mVal);
            string rValSorted = sortedStr(rVal);
            return lValSorted == mValSorted && mValSorted == rValSorted;
        }
    }
}
// 148748178147
// 296962999629
