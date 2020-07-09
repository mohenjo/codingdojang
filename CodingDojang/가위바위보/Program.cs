using System;

namespace CD194
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("[0] Rock, [1] Scissors, [2] Paper, [3] Exit : ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 3) { break; }
                    else if (input >= 0 && input < 3) { Game((RSP)input); } // 게임 수행
                    else { continue; }
                }
            }
        }

        enum RSP { Rock, Scissors, Paper } 

        static Random rnd = new Random();

        static void Game(RSP user) // user: 사용자 선택
        {
            int computer = rnd.Next(0, 3); // computer: 컴퓨터 선택
            // 판단부
            string result = string.Empty;
            if ((computer + 1) % 3 == (int)user) { result = "Computer wins."; }
            else if (((int)user + 1) % 3 == computer) { result = "User wins."; }
            else { result = "Draw game."; }

            Console.WriteLine($"Computer: {(RSP)computer}, User: {user} => {result}");
        }
    }
}
