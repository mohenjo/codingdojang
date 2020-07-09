using System;

namespace CD245
{
    class Program
    {
        static void Main()
        {
            SaltWater sw = GetInputFromConsole();
            Console.WriteLine(sw);
        }

        static SaltWater GetInputFromConsole()
        {
            // 키보드 입력은 항상 유효한 상태로 주어진다고 가정
            SaltWater sw = new SaltWater(0, 0);
            while (true)
            {
                string foo = Console.ReadLine().Trim();
                if (foo == "end") { break; }
                string[] bar = foo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double concentration = double.Parse(bar[0].Substring(0, bar[0].Length - 1));
                double totalWeigt = double.Parse(bar[1].Substring(0, bar[1].Length - 1));
                sw += new SaltWater(concentration, totalWeigt);
            }
            return sw;
        }
    }

    class SaltWater
    {
        /// <summary>
        /// 소금의 무게(g)
        /// </summary>
        public double SaltWeight { get; }

        /// <summary>
        /// 소금물의 농도(%)
        /// </summary>
        public double Concentration { get; }

        /// <summary>
        /// 소금물의 무게(g)
        /// </summary>
        public double TotalWeight { get; }

        /// <summary>
        /// 소금물의 인스턴스를 생성합니다.
        /// </summary>
        /// <param name="concentration">소금물의 농도(%)</param>
        /// <param name="totalWeight">소금물의 무게(g)</param>
        public SaltWater(double concentration, double totalWeight)
        {
            Concentration = concentration;
            TotalWeight = totalWeight;
            SaltWeight = Concentration * TotalWeight / 100.0;
        }

        public static SaltWater operator +(SaltWater sw1, SaltWater sw2)
        {
            double newTotalWeight = sw1.TotalWeight + sw2.TotalWeight;
            double newConcentration = (sw1.SaltWeight + sw2.SaltWeight) / newTotalWeight * 100.0;
            return new SaltWater(newConcentration, newTotalWeight);
        }

        public override string ToString()
        {
            return $"{Concentration:#.0#}% {TotalWeight:#.0#}g";
        }
    }
}
