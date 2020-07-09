using System;
using System.Linq;
using System.Text;

namespace CD051Cs
{
    class Program
    {
        static void Main()
        {
            int numberCases = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int test = 0; test < numberCases; test++)
            {
                int[] testCase = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                sb.AppendLine(GetStepLength(Math.Abs(testCase[0] - testCase[1])).ToString());
            }
            Console.WriteLine(sb);
        }

        // 숫자간의 거리를 D, 스텝의 길이를 SL이라고 할 때,
        // SL 1 2 3 4 5  6  7  8  9 10 ...
        // D  1 2 4 6 9 12 16 20 25 30 ... 이므로,
        // D = floor((SL + 1)**2 / 4)의 관계를 갖는다.  https://oeis.org/A002620 수열 참조
        static int GetStepLength(int distance)
        {
            int step = 0;
            int estimatedDistance = 0;
            while (distance > estimatedDistance)
            {
                estimatedDistance = (int)Math.Floor(Math.Pow(++step + 1, 2) / 4);
            }
            return step;
        }
    }
}
