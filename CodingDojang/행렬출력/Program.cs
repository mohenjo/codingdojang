using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD218
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int size = 10;
            GenMatrix(size);
            Console.ReadKey();
        }

        private static void GenMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int x = 0, y = 0, dx = 1, dy = 0; // 행렬위치 및 증가치
            for (var val = 1; val <= size * size; val++)
            {
                matrix[y, x] = val;
                // 다음 번의 x, y 좌표가 범위를 벗어나거나 숫자가 이미 입력되어 있으면 증가치 방향 전환
                bool check = x + dx < 0 || x + dx == size || y + dy < 0 || y + dy == size;
                if (check || matrix[y + dy, x + dx] > 0)
                {
                    int tmp = dx;
                    dx = -dy;
                    dy = tmp;
                }
                x += dx;
                y += dy;
            }

            StringBuilder sb = new StringBuilder();
            var maxLength = matrix.Cast<int>().Max().ToString().Length; // 가장 큰 숫자의 길이
            for (var posy = 0; posy < size; posy++)
            {
                sb.Append("|");
                for (var posx = 0; posx < size; posx++)
                {
                    // 가장 큰 숫자의 길이에 맞추어 정렬 출력
                    sb.Append($"{matrix[posy, posx].ToString().PadLeft(maxLength)}|");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}