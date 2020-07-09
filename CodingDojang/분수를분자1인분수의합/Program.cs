using System;
using System.Numerics;
using System.Collections.Generic;

namespace CD226
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("분자입력: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("분모입력: ");
            int denominator = int.Parse(Console.ReadLine());

            Fraction input = new Fraction(numerator, denominator);
            string result = string.Join(" + ", Fraction.GetEgyptianFraction(input));
            Console.WriteLine($"{input} = {result}");
        }
    }

    public class Fraction
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        public static Fraction operator -(Fraction fractionA, Fraction fractionB)
        {
            BigInteger lcm = LCM(fractionA.Denominator, fractionB.Denominator);
            BigInteger numerator = fractionA.Numerator * lcm / fractionA.Denominator
                - fractionB.Numerator * lcm / fractionB.Denominator;
            Fraction result = new Fraction(numerator, lcm);
            return result;
        }

        // 두 분수 인스턴스에 대해 통분된 표현의 분수 인스턴스 튜플을 반환합니다
        public static
            (Fraction, Fraction) ReductionToCommonDenominator(Fraction fractionA, Fraction fractionB)
        {
            BigInteger lcm = LCM(fractionA.Denominator, fractionB.Denominator);
            Fraction newFractionA =
                new Fraction(fractionA.Numerator * lcm / fractionA.Denominator, lcm);
            Fraction newFractionB =
                new Fraction(fractionB.Numerator * lcm / fractionB.Denominator, lcm);
            return (newFractionA, newFractionB);
        }

        public static bool operator >=(Fraction fractionA, Fraction fractionB)
        {
            (Fraction frA, Fraction frB) = ReductionToCommonDenominator(fractionA, fractionB);
            return frA.Numerator >= frB.Numerator;
        }

        public static bool operator <=(Fraction fractionA, Fraction fractionB)
        {
            (Fraction frA, Fraction frB) = ReductionToCommonDenominator(fractionA, fractionB);
            return frA.Numerator <= frB.Numerator;
        }

        // 주어진 분수 인스턴스를 이집트식 분수 표기법(단위 분수의 합)으로 변환합니다.
        public static List<Fraction> GetEgyptianFraction(Fraction fraction)
        {
            List<Fraction> fractions = new List<Fraction>();

            Fraction targetFraction = fraction;
            BigInteger lastDenominator = 2;
            while (targetFraction.Numerator != 1)
            {
                Fraction checkFraction = new Fraction(1, lastDenominator);
                while (checkFraction >= targetFraction)
                {
                    lastDenominator++;
                    checkFraction.Denominator++;
                }
                fractions.Add(checkFraction);
                targetFraction -= checkFraction;
                lastDenominator++;
            }
            fractions.Add(targetFraction);

            return fractions;
        }

        public static BigInteger GCD(BigInteger numberA, BigInteger numberB)
        {
            while (numberB != 0)
            {
                BigInteger temp = numberA % numberB;
                numberA = numberB;
                numberB = temp;
            }
            return numberA;
        }

        public static BigInteger LCM(BigInteger numberA, BigInteger numberB)
            => checked(numberA * numberB / GCD(numberA, numberB));
    }
}
