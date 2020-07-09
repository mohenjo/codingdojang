using System;

namespace CD020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] m = { 0, 1, 2, 1, 10, 11 }; // 총 건수
            int[] n = { 1, 1, 1, 10, 10, 10 }; // 페이지당 게시물 수

            for (int i = 0; i<m.Length; i++)
            {
                Console.Write($"총 건수: {m[i]}, 페이지당 게시물 수: {n[i]} -> ");
                Console.WriteLine( $"페이지 수: {GetNumberOfPage(m[i], n[i])}");
            }
        }

        static int GetNumberOfPage(int m, int n) => (int)Math.Ceiling((double)m / n);
    }
}
