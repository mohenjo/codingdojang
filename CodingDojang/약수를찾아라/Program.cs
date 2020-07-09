using System;
using System.Collections.Generic;
using System.Linq;

namespace CD209
{
    class Program
    {
        static void Main()
        {
            long inputNumber = long.Parse(Console.ReadLine());
            List<long> divisorsList = GetDivisors(inputNumber);
            Console.WriteLine($"{{ {string.Join(", ", divisorsList)} }}");
            Console.WriteLine($"약수의 개수는 {divisorsList.Count}개 입니다.");

            Console.ReadKey();
        }

        static List<long> GetDivisors(long aNumber)
        {
            SortedSet<long> divisors = new SortedSet<long>();
            for (long anum = 1; anum <= (long)Math.Sqrt(aNumber) + 1; anum++)
            {
                if (aNumber % anum == 0)
                {
                    divisors.Add(anum);
                    divisors.Add(aNumber / anum);
                }
            }
            return divisors.ToList();
        }
    }
}
