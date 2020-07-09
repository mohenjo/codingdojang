using System;
using System.Linq;

namespace CD037
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            while (true)
            {
                string input = Console.ReadLine();
                if (IsParsable(input, out int[] anArray))
                {
                    result += IsJolly(anArray) + Environment.NewLine;
                }
                else
                {
                    Console.WriteLine(result);
                    break;
                }
            }
        }

        static bool IsParsable(string aString, out int[] parsed)
        {
            string[] inp = aString.Split();
            int checkSize = int.Parse(inp[0]); // 입력 사이즈
            parsed = new int[checkSize];
            if (checkSize == 0) { return false; } // 입력 사이즈가 0인 경우 거짓 반환 |> 프로그램 종료
            for (int i = 0; i < parsed.Length; i++)
            {
                parsed[i] = int.Parse(inp[i + 1]);
            }
            return true;
        }

        static string IsJolly(int[] anArray)
        {
            int[] cnvArray = new int[anArray.Length - 1];
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                cnvArray[i] = Math.Abs(anArray[i] - anArray[i + 1]);
            }
            Array.Sort(anArray); Array.Sort(cnvArray);
            string result = "Not Jolly";
            if (anArray.Take(anArray.Length - 1).SequenceEqual(cnvArray)) { result = "Jolly"; }
            return result;
        }
    }
}
