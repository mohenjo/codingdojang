using System;
using System.Linq;

namespace CD058
{
    class Program
    {
        static void Main()
        {
            bool testResult;
            testResult = OneEditApart("cat", "dog");
            Console.WriteLine(testResult);
            testResult = OneEditApart("cat", "cats");
            Console.WriteLine(testResult);
            testResult = OneEditApart("cat", "cut");
            Console.WriteLine(testResult);
            testResult = OneEditApart("cat", "cast");
            Console.WriteLine(testResult);
            testResult = OneEditApart("cat", "at");
            Console.WriteLine(testResult);
            testResult = OneEditApart("cat", "acts");
            Console.WriteLine(testResult);
        }

        public static bool OneEditApart(string strA, string strB)
        {
            string strLong = strA.Length >= strB.Length ? strA : strB; //긴 문자열
            string strShort = strA.Length >= strB.Length ? strB : strA; // 짧은 문자열

            if (strLong.Length == strShort.Length) // 길이가 같을 경우
            {
                // 일치하는 문자의 개수가 문자열 길이 - 1 => OneEditApart true
                var matchCount = Enumerable.Range(0, strLong.Length)
                    .Where(idx => strLong[idx] == strShort[idx]).Count();
                return matchCount == strLong.Length - 1;
            }
            else // 길이가 다를 경우
            {
                // 긴 문자열에서 각 문자를 하나씩 뺸 컬렉션에 짧은 문자열 포함 => OneEditApart true
                var oneEdited = Enumerable.Range(0, strLong.Length)
                    .Select(idx => strLong.Remove(idx, 1));
                return oneEdited.Any(e => e == strShort);
            }
        }
    }
}
