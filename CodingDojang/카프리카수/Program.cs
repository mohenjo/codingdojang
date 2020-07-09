using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace CD214
{
    class Program
    {
        static void Main()
        {
            var result = new Kaprekar();

            // 유형 1
            Console.WriteLine(result.IsKaprekarNumber(1));
            Console.WriteLine(result.IsKaprekarNumber(45));
            Console.WriteLine(result.IsKaprekarNumber(297));
            Console.WriteLine(result.IsKaprekarNumber(3213));

            // 유형 2
            Console.WriteLine(string.Join(", ", result.GetNdigitKaprekarNumbers(5)));

            // 유형 3
            Console.WriteLine(string.Join(", ", result.GetKaprekarNumbersBelow(10000)));

            // 카프리카 상수
            Console.WriteLine(result.CountKaprekarRoutines(4371));
            Console.WriteLine(result.CountKaprekarRoutines(21));
            Console.WriteLine(result.CountKaprekarRoutines(1));
            Console.WriteLine(result.CountKaprekarRoutines(1111));

            Console.ReadKey();
        }
    }

    class Kaprekar
    {
        // (유형1) 카프리카 수인지 판단
        public bool IsKaprekarNumber(BigInteger aNum)
        {
            string str = (aNum * aNum).ToString();
            if (str.Length % 2 == 1) { str = "0" + str; }

            int divideIdx = str.Length / 2;
            BigInteger former = BigInteger.Parse(str.Substring(0, divideIdx));
            BigInteger latter = BigInteger.Parse(str.Substring(divideIdx, divideIdx));
            if (latter == 0) { return false; }

            return aNum == former + latter ? true : false;
        }

        // (유형2) ndigit 자리수의 카프리카 수 반환
        public List<BigInteger> GetNdigitKaprekarNumbers(int ndigit)
        {
            var result = new List<BigInteger>();
            for (var i = (BigInteger)Math.Pow(10, ndigit - 1); i < (BigInteger)Math.Pow(10, ndigit); i++)
            {
                if (IsKaprekarNumber(i)) { result.Add(i); }
            }
            return result;
        }

        // (유형 3) 특정 수 이하의 카프리카 수 반환
        public List<BigInteger> GetKaprekarNumbersBelow(BigInteger aNum)
        {
            var result = new List<BigInteger>();
            for (var i = 1; i <= aNum; i++)
            {
                if (IsKaprekarNumber(i)) { result.Add(i); }
            }
            return result;
        }

        // 카프리카 상수
        public string CountKaprekarRoutines(int aNum)
        {
            if (aNum <= 0 || aNum > 9999) { return false.ToString(); }

            int count = 0;
            int KaprekarConstant = 6174;
            do
            {
                string str = aNum.ToString().PadLeft(4, '0');
                if (str.Distinct().Count() == 1) { return false.ToString(); }
                var sorted = str.OrderByDescending(c => char.GetNumericValue(c)).ToArray();
                int bigger = int.Parse(new string(sorted));
                Array.Reverse(sorted);
                int smaller = int.Parse(new string(sorted));
                aNum = bigger - smaller;
                count++;
            } while (aNum != KaprekarConstant);

            return count.ToString();
        }
    }
}
