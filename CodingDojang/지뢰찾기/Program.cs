using System;
using System.Linq;

namespace CD034
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = InputAndParser(out int scaleY, out int scaleX);
            Mine mine = new Mine(scaleY, scaleX, matrix);
            mine.DisplaySolution();
        }

        // input & parser
        static string[,] InputAndParser(out int scaleY, out int scaleX)
        {
            int[] scale = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            scaleY = scale[0]; scaleX = scale[1];
            string[] lines = new string[scaleY];
            for (int line = 0; line < scaleY; line++)
            {
                lines[line] = Console.ReadLine();
            }
            // matrix parser
            string[,] matrix = new string[scaleY, scaleX];
            for (int row = 0; row < scaleY; row++)
            {
                for (int col = 0; col < scaleX; col++)
                {
                    matrix[row, col] = lines[row][col].ToString();
                }
            }
            return matrix;
        }
    }

    class Mine
    {
        private int scaleX, scaleY;
        private string[,] matrix; // 문제 매트릭스
        private string[,] matrixSolution; // 해답 매트릭스

        // constructor
        public Mine(int scaleY, int scaleX, string[,] matrix)
        {
            this.scaleY = scaleY; this.scaleX = scaleX;
            this.matrix = matrix;
            matrixSolution = new string[scaleY, scaleX];
        }

        private void GetSolution() // 전체 셀에 대한 카운트 계산
        {
            for (int row = 0; row < scaleY; row++)
            {
                for (int col = 0; col < scaleX; col++)
                {
                    CellCount(row, col);
                }
            }
        }

        private void CellCount(int posY, int posX) // 한 셀에 대한 카운트
        {
            int count = 0;
            for (int y = posY - 1; y <= posY + 1; y++)
            {
                if (y < 0 || y >= scaleY) { continue; }
                for (int x = posX - 1; x <= posX + 1; x++)
                {
                    if (x < 0 || x >= scaleX) { continue; }
                    if (matrix[y, x] == "*") { count++; }
                }
            }
            if (matrix[posY, posX] == "*") { matrixSolution[posY, posX] = "*"; }
            else { matrixSolution[posY, posX] = count.ToString(); }
        }

        public void DisplaySolution()
        {
            GetSolution();
            for (int row = 0; row < scaleY; row++)
            {
                for (int col = 0; col < scaleX; col++)
                {
                    Console.Write(matrixSolution[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}