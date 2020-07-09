using System;
using System.Collections.Generic;
using System.Linq;

namespace CD169
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("토지의 가로 세로 길이 입력 (ex. 640 400): ");
            // split on whitespace
            var input = Console.ReadLine()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList(); 
            var landSize = new List<int>();
            input.ForEach(item => landSize.Add(int.Parse(item)));

            int a = landSize.Max(), b = landSize.Min();
            int landArea = a * b, plantArea = GCD(a, b) * GCD(a, b);
            Console.WriteLine((int)(landArea/plantArea));
        }

        // a, b (a > b)의 최대공약수(유클리드 호제법)
        static int GCD(int a, int b)
        {
            if (b == 0) { return a; }
            else { return GCD(b, a % b); }
        }
    }
}
