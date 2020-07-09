using System;

namespace CD002
{
    class Program
    {
        static void Main(string[] args)
        {
            var mat = new Matrix(6, 6);
            mat.DisplayMatrix();
        }
    }

    class Matrix
    {
        private int[,] Mat;

        private readonly int EndValue;

        // 좌표 및 증가분 초기화
        private int IdxX = -1, IdxY = 0, Dx = 1, Dy = 0;

        public Matrix(int ysize, int xsize)
        {
            // 음의 값으로 매트릭스 초기화
            Mat = new int[ysize, xsize];
            for (int y = 0; y < ysize; y++)
            {
                for (int x = 0; x < xsize; x++)
                {
                    Mat[y, x] = -1;
                }
            }

            EndValue = ysize * xsize - 1;
            GenerateMatrix(); // 매트릭스 생성
        }

        // 매트릭스 생성
        private void GenerateMatrix()
        {
            for (int i = 0; i <= EndValue; i++)
            {
                CheckNext();
                IdxX += Dx; IdxY += Dy;
                Mat[IdxY, IdxX] = i;
            }
        }

        // 다음 입력 점이 범위를 벗어나거나 값이 이미 설정돼 있는 경우 증가 방향(Dy, Dx) 전환
        private void CheckNext()
        {
            bool check = true;
            if (IdxX + Dx == Mat.GetLength(1) || IdxX + Dx < 0 || IdxY + Dy == Mat.GetLength(0) || IdxY + Dy < 0)
            {
                check = false;
            }
            else if (Mat[IdxY + Dy, IdxX + Dx] >= 0)
            {
                check = false;
            }

            if (!check)
            {
                int tmp = Dy;
                Dy = Dx;
                Dx = -tmp;
            }
        }

        public void DisplayMatrix()
        {
            for (int y = 0; y < Mat.GetLength(0); y++)
            {
                for (int x = 0; x < Mat.GetLength(1); x++)
                {
                    Console.Write($"{Mat[y, x],3} ");
                }
                Console.WriteLine();
            }
        }
    }
}
