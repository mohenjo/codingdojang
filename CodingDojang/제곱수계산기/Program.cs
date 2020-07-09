using System;
using System.Collections.Generic;
using System.Linq;

namespace CD237
{
    class Program
    {
        static void Main()
        {
            var inputCases1 = new List<int>() { 1, 15, 16, 49, 64, 100, 256 };
            foreach (int inputCase in inputCases1)
            {
                var rst = GetPowerOfNaturalNumber(inputCase);
                Console.WriteLine($"{inputCase} = {rst.Item1}({rst.Item2}), 제곱수 여부: {rst.Item3}");
            }

            var inputCases2 = new List<string>() {"1(0)", "1(16)", "2(4)", "3(2)", "4(2)", "5(0)", "6(1)" };
            foreach (var inputCase in inputCases2)
            {
                int[] separated = 
                    inputCase.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s=>int.Parse(s)).ToArray();
                Console.WriteLine($"{inputCase} -> {GetNaturalNumber(separated[0], separated[1])}");
            }
        }

        // output1 계산 - (n, k, 제곱수 여부)의 튜플 반환
        static (int, int, bool) GetPowerOfNaturalNumber(int N)
        {
            if (N == 1) { return (1, 0, true); }
            int n = 0;
            double k;
            do
            {
                k = Math.Log(Math.Log(N, ++n), 2);
            } while (k != (int)k || k < 0);
            return (n, (int)k, Math.Sqrt(N) == (int)Math.Sqrt(N));
        }

        // output2 계산
        static int GetNaturalNumber(int n, int k) => (int)Math.Pow(n, Math.Pow(2, k));
    }
}
