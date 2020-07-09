using System;
using System.Linq;

namespace CD083
{
    class Program
    {
        static void Main()
        {
            int investValue = int.Parse(Console.ReadLine());
            int duration = int.Parse(Console.ReadLine());
            int[] valueChangeInPercent = new int[duration];
            valueChangeInPercent = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            Console.WriteLine(GetNetProfit(investValue, valueChangeInPercent));
        }

        static string GetNetProfit(int investValue, int[] valueChangeInPercent)
        {
            double balance = investValue;
            foreach (var change in valueChangeInPercent)
            {
                balance = balance * (1 + (double)change / 100);
            }
            double returnValue = Math.Round(balance - investValue);
            string EstimateString = returnValue > 0 ? "good" : "bad";
            if (returnValue == 0) { EstimateString = "same"; }

            return returnValue.ToString() + Environment.NewLine + EstimateString;
        }
    }
}
