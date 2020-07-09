using System;
using System.Text;

namespace CD195
{
    class Program
    {
        enum Digits { 영, 일, 이, 삼, 사, 오, 육, 칠, 팔, 구 };

        static void Main(string[] args)
        {
            bool result = Str2Num(Console.ReadLine(), out string converted);
            Console.WriteLine($"{converted} {result}");
        }

        static bool Str2Num(string aString, out string result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in aString)
            {
                // 숫자:그대로, Enum에 정의된 경우: 문자=>Enum.문자값
                if (Char.IsDigit(s)) sb.Append(s);
                else if (Enum.IsDefined(typeof(Digits), s.ToString()))
                {
                    sb.Append((int)Enum.Parse(typeof(Digits), s.ToString()));
                }
            }
            result = sb.ToString();
            // 길이 유효성 체크
            if (sb[2] == '0') return sb.Length == 11;
            else return sb.Length == 10 || sb.Length == 11;
        }
    }
}
