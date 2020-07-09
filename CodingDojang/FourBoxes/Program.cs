using System;
using System.Linq;

namespace CD010
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box;
            while (true)
            {
                var input = Console.ReadLine(); // input x1 y1 x2 y2
                if (input.Trim() == "") // enter to print area
                {
                    Console.WriteLine(Box.Area());
                    break;
                }
                box = new Box(input);
            } 
        }
    }

    class Box
    {
        static bool[,] Grid = new bool[1001, 1001];  // initialize with false

        public Box(string Coord)
        {
            var cnv = Coord.Split().Select(s => int.Parse(s)).ToArray();
            for (int y = cnv[1]; y < cnv[3]; y++) // y1, y2
            {
                for (int x = cnv[0]; x < cnv[2]; x++) // x1, x2
                {
                    Grid[y, x] = true;
                }
            }
        }

        public static int Area()
        {
            int count = 0;
            foreach (var cell in Grid)
            {
                if (cell) count++;
            }
            return count;
        }
    }
}
