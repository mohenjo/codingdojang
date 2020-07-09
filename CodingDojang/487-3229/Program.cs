using System;
using System.Linq;
using System.Text;
using System.IO;

namespace CD054
{

    class Program
    {
        static void Main()
        {
            // read input & convert phone numbers
            string path = @"C:\Temp\PhoneNumbers.txt";
            StreamReader f = new StreamReader(path);
            int numLines = int.Parse(f.ReadLine());
            string[] input = new string[numLines];
            for (int line = 0; line < numLines; line++)
            {
                input[line] = (new PhoneNumber(f.ReadLine())).CnvNumber;
            }
            f.Close();

            // 입력 내용을 번호, 반복회수로 사전타입에 저장
            var result = (from e in input
                         group e by e into newGroup
                         orderby newGroup.Key
                         select newGroup).ToDictionary(e => e.Key, e => e.Count());
            bool hasDuplicates = false; // 반복 발생 여부
            foreach (var e in result)
            {
                if (e.Value > 1)
                {
                    Console.WriteLine($"{e.Key} {e.Value}");
                    hasDuplicates = true;
                }
            }
            if (!hasDuplicates) { Console.WriteLine("No duplicates."); }
        }
    }

    class PhoneNumber
    {
        private enum PL { ABC = 2, DEF, GHI, JKL, MNO, PRS, TUV, WXY };

        // 생성자
        public PhoneNumber(string aString) => CnvNumber = StringToNumber(aString);

        public string CnvNumber { get; } = string.Empty; // 변환된 전화번호

        // 키패드 문자가 포함된 문자열을 숫자로 구성된 전화번호 형식으로 변환
        private static string StringToNumber(string aString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in aString)
            {
                if (!Char.IsLetterOrDigit(c)) continue; // 숫자 또는 문자가 아닌 경우 제외
                if (Char.IsLetter(c)) // 문자일 경우
                {
                    foreach (var key in Enum.GetNames(typeof(PL)))
                    {
                        if (key.Contains(c))
                        {
                            sb.Append((int)Enum.Parse(typeof(PL), key)); // 해당 숫자로 변환
                            break;
                        }
                    }
                }
                else { sb.Append(c); } // 숫자일 경우
            }
            string result = sb.ToString();
            return $"{result.Substring(0, 3)}-{result.Substring(3)}";
        }
    }
}
