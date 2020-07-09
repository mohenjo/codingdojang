using System;
using System.Collections.Generic;
using System.Text;

namespace CD242
{
    class Program
    {
        static void Main()
        {
            // 참가자, 완주자 생성
            int numPlayers = int.Parse(Console.ReadLine());
            var generated = GeneratePlayers(numPlayers);
            var participants = generated.Item1;
            var completions = generated.Item2;

            // 참가자 리스트에서 완주자 요소 제거
            foreach (string completion in completions)
            {
                participants.Remove(completion);
            }
            string incomplete = participants[0];
            Console.WriteLine(incomplete);
        }

        // 선수 이름 생성 및 (참가자, 완주자) 튜플 반환
        static (List<string>, List<string>) GeneratePlayers(int players)
        {
            List<string> participants = new List<string>();
            Random rnd = new Random();
            for (int player = 0; player < players; player++)
            {
                int nameLength = rnd.Next(1, 21);
                StringBuilder sb = new StringBuilder();
                for (int len = 0; len < nameLength; len++)
                {
                    sb.Append((char)rnd.Next('a', 'z' + 1));
                }
                participants.Add(sb.ToString());
            }
            List<string> completions = new List<string>(participants);
            int removeIndex = rnd.Next(players);
            completions.RemoveAt(removeIndex);

            return (participants, completions);
        }
    }
}
