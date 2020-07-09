using System;
using System.Collections.Generic;

namespace CD021
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("첫 번째 인자 [예: 10 cm]: ");
                string[] input1 = Console.ReadLine().Split();
                if (input1[0] == "") { break; }
                Console.Write("두 번째 인자 [예: inch]: ");
                string input2 = Console.ReadLine();

                var unit = new Units(double.Parse(input1[0]), input1[1], input2);
                Console.WriteLine(unit.Converted);
            }
        }
    }

    class Units
    {
        private static readonly Dictionary<string, double> Unit = new Dictionary<string, double>();

        static Units() // initialize static members (Unit)
        {
            Unit["inch"] = 1;
            Unit["cm"] = Unit["inch"] / 2.54;
            Unit["mm"] = Unit["cm"] / 10.0;
            Unit["pt"] = Unit["inch"] / 72.0;
            Unit["px"] = Unit["inch"] / 96.0;
            Unit["dxa"] = Unit["pt"] / 20.0;
            Unit["emu"] = Unit["dxa"] / 635.0;
        }

        private double originalValue;

        private string originalUnit, targetUnit;

        public Units(double originalValue, string originalUnit, string targetUnit)
        {
            this.originalValue = originalValue;
            this.originalUnit = originalUnit;
            this.targetUnit = targetUnit;
        }

        // 단위 변환된 문자열 반환
        public string Converted 
            => (originalValue * Unit[originalUnit] / Unit[targetUnit]).ToString() + " " + targetUnit;
    }
}
