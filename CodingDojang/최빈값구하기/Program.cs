using System;
using System.Collections.Generic;
using System.Linq;

namespace CD187
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> testCase;
            testCase = new List<int>() { 12, 17, 19, 17, 23 };
            Console.WriteLine(Mode(testCase));
            testCase = new List<int>() { 26, 37, 26, 37, 91 };
            Console.WriteLine(Mode(testCase));
            testCase = new List<int>() { 28, 30, 32, 34, 144 };
            Console.WriteLine(Mode(testCase));
        }

        private static string Mode(List<int> list)
        {
            // 딕셔너리 구성(key = 숫자, value = 리스트 내의 개수)
            var countDic = list.GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count());
            // 딕셔너리 아이템의 중복 개수가 중복 개수의 최대값과 동일한 아이템 개수 계산
            int maxVal = countDic.Values.Max();
            int criteria = countDic.Where(g => g.Value == maxVal).Select(g => g.Key).Count();
            // 동일한 아이템 개수 == 리스트의 항목 개수인 경우(즉, 모두 같거나, 모두 다르거나) 최빈값 없음
            string result = criteria == list.Count() ? "없다" :
                // 그렇지 않은 경우 딕셔너리 키(리스트 항목)(들을) 반환
                string.Join(", ", countDic.Where(g => g.Value == maxVal).Select(g => g.Key));
            return result;
        }
    }
}