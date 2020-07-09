using System;
using System.Linq;

namespace CD038
{
    class Program
    {
        static void Main(string[] args)
        {
            Roach roach = new Roach(20, 20, 5, 5);
            roach.LetMeMove();
            roach.DisplayResult();
        }
    }

    class Roach
    {
        private int scaleY, scaleX; // 매트릭스 크기
        private int[,] matrix; // 매트릭스 방문횟수
        private int remainCount; // 방문하지 않은 셀 갯수
        private int moveCount = 0; // 바퀴벌레 이동 횟수
        private int posY, posX; // 바퀴벌레 현재 위치

        // constructor
        public Roach(int scaleY, int scaleX, int posY, int posX)
        {
            this.scaleY = scaleY; this.scaleX = scaleX;
            remainCount = scaleY * scaleX;
            matrix = new int[scaleY, scaleX];
            this.posY = posY; this.posX = posX;
        }

        // 바퀴벌레 이동
        public void LetMeMove()
        {
            matrix[posY, posX] += 1; remainCount--; // 초기 위치
            Random rnd = new Random();
            while (remainCount > 0)
            {
                int nextY, nextX; // 다음 이동 예상 위치
                do
                {
                    int dy = rnd.Next(-1, 2), dx = rnd.Next(-1, 2);
                    nextY = posY + dy; nextX = posX + dx;
                } while ((nextY == posY && nextX == posX) || // 반드시 이동하는 것으로 가정
                        nextY < 0 || nextY >= scaleY || nextX < 0 || nextX >= scaleX);

                posY = nextY; posX = nextX;
                if (matrix[posY, posX] == 0) { remainCount--; }
                matrix[posY, posX] += 1;
                moveCount++;
            }
        }

        // 결과 출력
        public void DisplayResult()
        {
            // 움직인 횟수 최대값의 길이 -> 셀 출력 길이 설정
            int maxLength = (from int count in matrix select count).Max().ToString().Length;

            for (int row = 0; row < scaleY; row++)
            {
                for (int col = 0; col < scaleX; col++)
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(maxLength + 1));
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Move count: {moveCount}");
        }
    }
}