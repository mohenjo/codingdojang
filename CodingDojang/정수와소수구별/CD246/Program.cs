using System;

namespace CD246
{
    class Program
    {
        static void Main()
        {
            string rst = CheckType(Console.ReadLine());
            Console.WriteLine(rst);
        }

        static string CheckType(string input)
        {
            // 입력 문자열을 실수로 변환 가능한지 여부 판단
            bool isNumeric = double.TryParse(input, out double parsedNumber);
            if (!isNumeric)
            {
                return "math error";
            }
            // 실수 값이 정수 변환 값과 같은지 판단
            return parsedNumber == (int)parsedNumber ? "정수" : "소수";
        }
    }
}
