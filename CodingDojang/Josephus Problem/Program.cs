using System;
using System.Collections.Generic;
using System.Linq;

namespace CD060
{
    class Program
    {
        static void Main()
        {
            int numberOfSolders = 10;
            int skip = 3;
            Console.WriteLine(Josephus(numberOfSolders, skip));
        }

        static int Josephus(int n, int k)
        {
            List<int> solders = Enumerable.Range(1, n).ToList();
            int idx = k;
            while (solders.Count > 1)
            {
                solders.RemoveAt(idx - 1);
                idx += (k - 1);
                if (idx > solders.Count) { idx -= solders.Count; }
            }
            return solders[0];
        }
    }
}
