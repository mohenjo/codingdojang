using System;
using System.Linq;

namespace CD162
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("순환 소수: ");
            string repeatingDecimal = Console.ReadLine();
            Console.Write("순환 마디: ");
            string repetend = Console.ReadLine();

            Console.WriteLine(ToFraction(repeatingDecimal, repetend));
            Console.ReadKey();
        }

        private static string ToFraction(string repeatingDecimal, string repetend)
        {
            // 소숫점 이하 길이 및 순환 마디의 길이로 부터 양변에 곱할 10^? 크기 구함
            int decimalLenAfterPoint = repeatingDecimal.Split('.').Last().Length;
            int nonRepetendLenAfterPoint = decimalLenAfterPoint - repetend.Length;
            int powForDecimal = (int)(Math.Pow(10, decimalLenAfterPoint));
            int powForRepentend = (int)(Math.Pow(10, nonRepetendLenAfterPoint));
            // 좌변
            int leftHand = powForDecimal - powForRepentend;
            // 우변
            int righrHand = (int)(decimal.Parse(repeatingDecimal) * powForDecimal)
                - (int)(decimal.Parse(repeatingDecimal) * powForRepentend);
            // 기약분수
            int gcd = Gcd(leftHand, righrHand);
            return $"{righrHand / gcd}/{leftHand / gcd}";
        }

        private static int Gcd(int a, int b) // 최대공약수
        {
            int lg = a > b ? a : b;
            int sm = a > b ? b : a;
            return b == 0 ? a : Gcd(b, a % b);
        }
    }
}