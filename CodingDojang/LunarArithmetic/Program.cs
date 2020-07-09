using System;
using System.Collections.Generic;
using System.Text;

namespace CD241
{
    class Program
    {
        static void Main()
        {
            List<int[]> testCases = new List<int[]>()
            {
                new int[]{5, 3},
                new int[]{13, 6},
                new int[]{169, 248},
            };

            foreach (int[] test in testCases)
            {
                var value1 = new Lunar(test[0]);
                var value2 = new Lunar(test[1]);
                Console.WriteLine($"{value1.NumValue} + {value2.NumValue} = {(value1 + value2).NumValue}");
                Console.WriteLine($"{value1.NumValue} * {value2.NumValue} = {(value1 * value2).NumValue}");
            }
        }
    }

    class Lunar
    {
        public int NumValue { get; } // Lunar 인스턴스의 숫자값

        public string StrValue { get; } // Lunar 인스턴스 숫자값의 문자열 표현

        public int Length => StrValue.Length; // Lunar 인스턴스 숫자값의 길이

        public Lunar(int aNumber)
        {
            NumValue = aNumber;
            StrValue = aNumber.ToString();
        }

        // + 연산자 오버라이딩
        public static Lunar operator +(Lunar lunar1, Lunar lunar2)
        {
            // + 연산을 수행할 값의 길이를 맞춤
            (int length, string string1, string string2) =
                PadLeftLongest(lunar1.StrValue, lunar2.StrValue);

            // 각 자리별 최대값을 선택하여 Lunar 인스턴스 반환
            StringBuilder sb = new StringBuilder();
            for (int idx = 0; idx < length; idx++)
            {
                int addValue =
                    (int)Math.Max(char.GetNumericValue(string1[idx]),
                    char.GetNumericValue(string2[idx]));
                sb.Append(addValue);
            }
            return new Lunar(int.Parse(sb.ToString()));
        }

        // * 연산자 오버라이딩
        public static Lunar operator *(Lunar lunar1, Lunar lunar2)
        {
            Lunar result = new Lunar(0);
            // 각 자리별로 최소값을 선택
            for (int idx1 = 0; idx1 < lunar1.Length; idx1++)
            {
                StringBuilder sb = new StringBuilder();
                for (int idx2 = 0; idx2 < lunar2.Length; idx2++)
                {
                    int addValue =
                        (int)Math.Min(char.GetNumericValue(lunar1.StrValue[idx1]),
                        char.GetNumericValue(lunar2.StrValue[idx2]));

                    sb.Append(addValue);
                }
                // 각 자리별 * 연산자 결과에 대한 + 연산자 수행을 위해 자리수 맞춤
                sb.Append(new string('0', lunar1.Length - idx1 - 1));
                result += new Lunar(int.Parse(sb.ToString()));
            }
            return result;
        }

        // 두 문자열 중 긴 문자열을 기준으로 좌측에 '0'을 채워 반환
        public static (int, string, string) PadLeftLongest(string string1, string string2)
        {
            int maxLength = Math.Max(string1.Length, string2.Length);
            return (maxLength, string1.PadLeft(maxLength, '0'), string2.PadLeft(maxLength, '0'));
        }
    }
}
