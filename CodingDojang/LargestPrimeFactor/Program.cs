using System;

namespace CD063
{
    class Program
    {
        static void Main()
        {
            long result = GetMaxPrimeFactor(600851475143);
            Console.WriteLine(result);
        }

        static long GetMaxPrimeFactor(long number)
        {
            long maxPrimeFactor = 0;
            long targetValue = number;
            long checkValue = 2;
            while (checkValue*checkValue <= targetValue)
            {
                if (targetValue % checkValue == 0)
                {
                    maxPrimeFactor = checkValue;
                    while (targetValue % checkValue == 0) { targetValue /= checkValue; }
                }
                else { checkValue++; }
            }
            if (targetValue > maxPrimeFactor) { maxPrimeFactor = targetValue; }

            return maxPrimeFactor;
        }
    }
}
