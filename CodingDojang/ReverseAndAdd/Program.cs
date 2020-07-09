using System;

namespace CD045
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeat = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < repeat; i++)
            {
                ReverseAndAdd newWork = new ReverseAndAdd(Console.ReadLine());
                result += newWork.Count() + Environment.NewLine;
            }
            Console.WriteLine(result);
        }
    }

    sealed class ReverseAndAdd
    {
        private static bool IsPalindrome(string aNumStr) => aNumStr == ReverseNumStr(aNumStr);

        private static string GenerateNext(string aNumStr) =>
            (uint.Parse(aNumStr) + uint.Parse(ReverseNumStr(aNumStr))).ToString();

        private static string ReverseNumStr(string aNumStr)
        {
            char[] tmpChr = aNumStr.ToCharArray(); Array.Reverse(tmpChr);
            return new string(tmpChr);
        }

        private string checkNumStr;
        private int count = 0; // 제너레이션 반복 횟수

        // 생성자
        public ReverseAndAdd(string aNumStr) => checkNumStr = aNumStr;

        public string Count() // 결과 반환
        {
            while (!IsPalindrome(checkNumStr))
            {
                checkNumStr = GenerateNext(checkNumStr);
                count++;
            }
            return $"{count} {checkNumStr}";
        }
    }
}
