using System;

namespace CD164
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("양의 정수 입력: ");
            var input = int.Parse(Console.ReadLine());

            Console.WriteLine($"{input} > {(int)Math.Log10(input) + 1}자리수");
        }
    }
}
