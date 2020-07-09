using System;
using System.Collections.Generic;
using System.Linq;

namespace CD173
{
    internal class Program
    {
        private static void Main()
        {
            Numerology testCase;
            // --- File #1 ---
            testCase = new Numerology(6);
            testCase.PrintFile1Status();
            testCase = new Numerology(20);
            testCase.PrintFile1Status();
            testCase = new Numerology(15);
            testCase.PrintFile1Status();
            // --- File #2 ---
            testCase = new Numerology(220);
            testCase.PrintFile2Status();
            testCase = new Numerology(75);
            testCase.PrintFile2Status();
            testCase = new Numerology(20);
            testCase.PrintFile2Status();
        }
    }

    internal class Numerology
    {
        private readonly int TargetNumber;

        public Numerology(int number)
        {
            TargetNumber = number;
        }

        public void PrintFile1Status() // File #1 상태 출력
        {
            int sum = SumProperDivisors(TargetNumber);
            string status = TargetNumber == sum ? "완전수" :
                TargetNumber > sum ? "부족수" : "과잉수";
            Console.WriteLine($"{status}입니다.");
        }

        public void PrintFile2Status() // File #2 상태 출력
        {
            int sum = SumProperDivisors(TargetNumber);
            string status = string.Empty;
            if (IsAmicable(TargetNumber))
            {
                status = $"{sum}, 친화수";
            }
            else if (IsQuasiAmicable(TargetNumber))
            {
                status = $"{sum - 1}, 혼약수";
            }
            else
            {
                status = $"{sum}, 일반수";
            }
            Console.WriteLine($"{status}입니다.");
        }

        private static bool IsAmicable(int number) // 친화수 판단
        {
            var tmpVal = SumProperDivisors(number);
            return number == SumProperDivisors(tmpVal);
        }

        private static bool IsQuasiAmicable(int number) // 혼약수 판단
        {
            var tmpVal = SumProperDivisors(number) - 1;
            return number == SumProperDivisors(tmpVal) - 1;
        }

        private static int SumProperDivisors(int number) // 진약수 합
        {
            var properDivisors = new HashSet<int>() { 1 };
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    properDivisors.Add(i);
                    properDivisors.Add(number / i);
                }
            }
            return properDivisors.Sum();
        }
    }
}