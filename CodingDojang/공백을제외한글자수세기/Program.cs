using System;

namespace CD165
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"공백을 제외한
글자수만을 세는 코드 테스트";
            Console.WriteLine(NumChar(input));
        }

        static int NumChar(string args)
        {
            string newString = args.Replace(" ", "");
            newString = newString.Replace(Environment.NewLine, "");
            return newString.Length;
        }
    }
}
