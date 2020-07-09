using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input Number: ");
        int number = int.Parse(Console.ReadLine());
        int numDigit = (int)Math.Log10(number); // n자리수 A에 대해 Log10(A) => (n-1). ...
        Console.WriteLine($"{(int)Math.Pow(10,numDigit)}의 자릿수");
    }
}
