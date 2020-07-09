using System;

namespace CD171
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("문자(열)를 입력하세요: ");
            var input = Console.ReadLine();
            foreach (char val in input)
            {
                // ascii code는 unicode의 subset
                Console.WriteLine($"[{val}] => 유니코드로 {(int)val}(DEC), {(int)val:X}(HEX)입니다.");
            }
        }
    }
}
