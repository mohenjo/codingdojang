using System;

namespace CD001
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = 5000;
            var dn = new Dn(upperLimit);
            Console.WriteLine(dn.SumSelfNumber); // 1227365
        }
    }

    class Dn
    {
        private int UpperLimit { get; }

        private bool[] DnList { get; }

        private int FuncDn(int aNumber)
        {
            int result = aNumber;
            foreach (var val in aNumber.ToString()) { result += (int)Char.GetNumericValue(val); }
            return result;
        }

        public Dn(int upperLimit)
        {
            UpperLimit = upperLimit;
            DnList = new bool[UpperLimit];

            for (int n = 1; n < UpperLimit; n++)
            {
                int tmpInt = FuncDn(n);
                if (tmpInt < UpperLimit) DnList[tmpInt] = true;
            }
        }

        public int SumSelfNumber
        {
            get
            {
                int sum = 0;
                for (int idx = 1; idx < UpperLimit; idx++)
                {
                    if (!DnList[idx]) sum += idx;
                }
                return sum;
            }
        }
    }
}
