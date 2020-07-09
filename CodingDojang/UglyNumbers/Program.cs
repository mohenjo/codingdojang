using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CD049
{
    class Program
    {
        static void Main()
        {
            UglyNumber testCase;
            testCase = new UglyNumber(1500); Console.WriteLine(testCase.NthNumber);
            testCase = new UglyNumber(1550); Console.WriteLine(testCase.NthNumber);
            testCase = new UglyNumber(100000); Console.WriteLine(testCase.NthNumber);
        }
    }

    class UglyNumber
    {
        private readonly int nth;

        public BigInteger NthNumber => CalculateNthNumber();

        public UglyNumber(int nth)
        {
            this.nth = nth;
        }

        private BigInteger CalculateNthNumber()
        {
            List<BigInteger> uglyNumbers = new List<BigInteger>();
            SortedSet<BigInteger> processNumbers = new SortedSet<BigInteger>() { 1 };
            BigInteger checkNumber = processNumbers.Min();
            while (uglyNumbers.Count() < nth)
            {
                processNumbers.Add(checkNumber * 2);
                processNumbers.Add(checkNumber * 3);
                processNumbers.Add(checkNumber * 5);
                // ugly number 리스트에 최소값 이동
                uglyNumbers.Add(processNumbers.Min());
                // 이동 후 최소값에 대해 연산 반복
                processNumbers.Remove(checkNumber);
                checkNumber = processNumbers.Min();
            }
            return uglyNumbers[nth - 1];
        }
    }
}
