using System;
using System.Linq;

namespace CD024
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "이유덕,이재영,권종표,이재영,박민호,강상희,이재영,김지완,최승혁,이성연,박영서,박민호,전경헌,송정환,김재성,이유덕,전경헌";

            var names = new Names(input);
            Console.WriteLine($"김씨 {names.KimCount}명, 이씨 {names.LeeCount}명");
            Console.WriteLine($"이재영 {names.LJYCount}명");
            Console.Write("중복제외 이름: ");
            foreach (var n in names.NameDistinct) { Console.Write($"{n} "); }
            Console.WriteLine();
            Console.Write("중복제외 이름(오름차순): ");
            foreach (var n in names.NameDistinct.OrderBy(i => i)) { Console.Write($"{n} "); }
            Console.WriteLine();
        }
    }

    class Names
    {
        private readonly string[] name;

        public Names(string aString)
        {
            name = aString.Split(',');
        }

        // 김씨 수 반환
        public int KimCount
            => (from n in name where n[0] == '김' select n).Count();

        // 이씨 수 반환
        public int LeeCount
            => (from n in name where n[0] == '이' select n).Count();

        // 이재영 수 반환
        public int LJYCount
            => (from n in name where n == "이재영" select n).Count();

        // 중복 제외 출력
        public string[] NameDistinct => name.Distinct().ToArray();
    }
}
