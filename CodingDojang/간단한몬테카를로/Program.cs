using System;

namespace CD108
{
    class Program
    {
        static Random position = new Random();

        static void Main()
        {
            int tryCase = 5_000_000;
            Console.WriteLine($"n = {tryCase}, pi = {GetPiValue(tryCase)}");
        }

        static double GetPiValue(int tryCase)
        {
            double posX, posY;
            int count = 0;
            for (int i = 0; i < tryCase; i++)
            {
                posX = position.NextDouble();
                posY = position.NextDouble();
                if (posX * posX + posY * posY <= 1.0) { count++; }
            }
            return (double)count / tryCase * 4.0;
        }
    }
}
