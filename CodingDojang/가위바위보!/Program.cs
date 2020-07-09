using System;

namespace CD213
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("'가위', '바위', '보' 또는 엔터(종료): ");
                string input = Console.ReadLine().Trim();
                if (input == "") { break; }
                if (input == "가위" || input == "바위" || input == "보")
                {
                    var userSelection = (RSP)Enum.Parse(typeof(RSP), input);
                    Game(userSelection);
                }
                else { continue; }
            }
        }

        enum RSP { 가위, 바위, 보 } // [0, 1, 2]

        static Random rnd = new Random();

        static void Game(RSP userSelection)
        {
            int comSelection = rnd.Next(0, 3); // 컴퓨터 선택 [0, 1, 2]
            // 승자 판단:
            // 가위(0), 바위(1), 보(2) 순환 판단을 위해 3으로 나눈 나머지로 접급
            // 예>
            // - 사용자: 보(2) / 컴퓨터: 가위(0) 의 경우
            // - 사용자[(보 + 1) % 3 = 0] == 컴퓨터[0] 조건에 의해 컴퓨터 승 
            string result = string.Empty;
            if ((comSelection + 1) % 3 == (int)userSelection)
            {
                result = "유저 승";
            }
            else if (((int)userSelection + 1) % 3 == comSelection)
            {
                result = "컴퓨터 승";

            }
            else { result = "비김"; }

            Console.WriteLine($"유저: {userSelection} vs 컴퓨터: {(RSP)comSelection} => {result}");
        }
    }
}
