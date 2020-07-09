using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        Enumerable.Range(1, 10000).ToList().ForEach(e => sum += e.ToString().Count(n => n == '8'));
        Console.WriteLine(sum);
    }
}
