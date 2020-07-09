using System;
using System.Collections.Generic;

namespace CD003
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            string[] input = new string[2];
            while (true)
            {
                input = Console.ReadLine().Split();
                if (input[0] == "0" && input[1] == "0") { break; }
                result += ToLCDString(input[0], input[1]) + Environment.NewLine;
            }
            Console.WriteLine(result);
        }

        // LCD 문자열 출력
        static string ToLCDString(string scaleStr, string numbersStr)
        {
            string result = string.Empty;

            int scale = int.Parse(scaleStr);

            int length = 3 + scale * 2; // LCD 문자의 높이(리스트 용량)
            var LCDList = new List<string>(); // 여러 숫자의 LCD 문자열
            for (int i = 0; i < length; i++) { LCDList.Add(String.Empty); }

            foreach (var val in numbersStr)
            {
                LCD lcd = new LCD((int)Char.GetNumericValue(val), scale);
                for (var idx = 0; idx < length; idx++)
                {
                    LCDList[idx] += lcd[idx] + " ";
                }
            }

            for (var idx = 0; idx < length; idx++)
            {
                result += LCDList[idx] + Environment.NewLine;
            }
            return result;
        }
    }

    class LCD
    {
        // 숫자 -> LCD
        // h: -, n: 빈칸, l: 왼쪽 | , r: 오른쪽 |, b: 양쪽 ||
        private static Dictionary<int, string> Dic = new Dictionary<int, string>()
        {
            {0, "hbnbh" },{1, "nrnrn" },{2, "hrhlh" },{3, "hrhrh" },{4, "nbhrn" },
            {5, "hlhrh" },{6, "hlhbh" },{7, "hrnrn" },{8, "hbhbh" },{9, "hbhrh" },
        };

        private static string LCDLine(char type, int scale)
        {
            string result = string.Empty;
            switch (type)
            {
                case 'h':
                    result = " " + new string('-', scale) + " ";
                    break;
                case 'b':
                    result = "|" + new string(' ', scale) + "|";
                    break;
                case 'l':
                    result = "|" + new string(' ', scale) + " ";
                    break;
                case 'r':
                    result = " " + new string(' ', scale) + "|";
                    break;
                case 'n':
                    result = " " + new string(' ', scale) + " ";
                    break;
            }
            return result;
        }

        // 1개의 숫자 및 크기에 대한 LCD 문자열 리스트
        private List<string> LCDString = new List<string>();

        public LCD(int aNumber, int scale)
        {
            for (int idx = 0; idx < Dic[aNumber].Length; idx++)
            {
                if (idx % 2 == 0)
                {
                    LCDString.Add(LCDLine(Dic[aNumber][idx], scale));
                }
                else
                {
                    for (int i = 0; i < scale; i++)
                    {
                        LCDString.Add(LCDLine(Dic[aNumber][idx], scale));
                    }
                }
            }
        }

        public string this[int row] => LCDString[row];
    }
}
