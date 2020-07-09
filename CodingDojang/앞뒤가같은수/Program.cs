using System;
using System.Collections.Generic;
using System.Linq;

namespace CD015
{
    class Program
    {
        static void Main(string[] args)
        {
            Palindrome test;
            test = new Palindrome(1);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
            test = new Palindrome(4);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
            test = new Palindrome(30);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
            test = new Palindrome(100);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
            test = new Palindrome(30000);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
            test = new Palindrome(1000000);
            Console.WriteLine($"{test.Nth} => {test.GetPalindrome}");
        }
    }

    class Palindrome
    {
        public int Nth { get; } // Palindrome 리스트의 Nth 번째 요소

        // constructor
        public Palindrome(int nth)
        {
            Nth = nth;
        }

        // Nth 번째 palindrome number 반환
        public string GetPalindrome
        {
            get
            {
                int checkPlace = 1;
                bool IsOver = false;
                while (!IsOver)
                {
                    if (Nth <= GetAccumulatedPalindromeCount(checkPlace))
                    {
                        IsOver = true;
                    }
                    else
                    {
                        checkPlace++;
                    }
                }
                // checkPlace: Pow(10, checkPlace-1) 자리수 Palindrome 리스트에 Nth 번쨰 수가 포함됨
                int nthInnPlace = Nth - GetAccumulatedPalindromeCount(checkPlace - 1); // 해당 자리수 내 요소 위치
                return GeneratenPlacePalindrome(checkPlace)[nthInnPlace - 1];
            }
        }

        // nPlcae 자리수(= Pow(10, nPlace-1))까지의 Palindrome 개수(누적) 반환
        // nPlace      count accumulative count
        // 1(0..9)     10    10
        // 2(11..99)   9     19
        // 3(101..999) 90    109
        // ...
        private static int GetAccumulatedPalindromeCount(int nPlace)
        {
            int result = 0;
            if (nPlace == 0)
            {
                result = 0;
            }
            else if (nPlace == 1)
            {
                result = 10;
            }
            else
            {
                if (nPlace % 2 == 0)
                {
                    result = GetAccumulatedPalindromeCount(nPlace - 1)
                        + 9 * (int)Math.Pow(10, nPlace / 2 - 1);
                }
                else
                {
                    result = GetAccumulatedPalindromeCount(nPlace - 1)
                        + 9 * (int)Math.Pow(10, (nPlace - 1) / 2);
                }
            }
            return result;
        }

        // nPlace 자리수(= Pow(10, nPlace-1))에 해당하는 Palindrome 리스트<string> 생성
        public static List<string> GeneratenPlacePalindrome(int nPlace)
        {
            List<string> result = new List<string>();
            if (nPlace == 1) // 1의 자리 [0..9] 
            {
                result = (from val in Enumerable.Range(0, 10) select val.ToString()).ToList();
            }
            else
            {
                if (nPlace % 2 == 0)
                {
                    int startValue = (int)Math.Pow(10, nPlace / 2 - 1);
                    int count = (int)Math.Pow(10, nPlace / 2) - startValue;
                    foreach (var val in Enumerable.Range(startValue, count))
                    {
                        result.Add(val.ToString() + ReverseNumber(val));
                    }
                }
                else
                {
                    int startValue = (int)Math.Pow(10, (nPlace - 1) / 2 - 1);
                    int count = (int)Math.Pow(10, (nPlace - 1) / 2) - startValue;
                    foreach (var val in Enumerable.Range(startValue, count))
                    {
                        foreach (var midVal in Enumerable.Range(0, 10))
                        {
                            result.Add(val.ToString() + midVal.ToString() + ReverseNumber(val));
                        }
                    }
                }
            }
            return result;
        }

        private static string ReverseNumber(int aNumber) // 숫자의 역순 문자열 반환
        {
            return new string(aNumber.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}
