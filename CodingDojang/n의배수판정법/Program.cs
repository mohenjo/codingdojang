using System;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main()
    {
        // 구현
        Func<int, int, string> func = (dividend, divisor)
            => Enumerable.Range(0, dividend).Select(i => i * divisor).Contains(dividend) ? "1" : "0";

        // 테스트
        int numCases = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int nc = 0; nc < numCases; nc++)
        {
            var args = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            sb.AppendLine(func(args[0], args[1]));
        }
        Console.WriteLine(sb.ToString());
    }
}
