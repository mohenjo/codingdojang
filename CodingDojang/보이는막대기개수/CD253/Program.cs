using System;
using System.Collections.Generic;
using System.Linq;

namespace CD253
{
    class Program
    {
        static void Main()
        {
            int numOfBars = int.Parse(Console.ReadLine());

            List<int> barFromRight = new List<int>(); // 우측에서 보는 시점의 막대기 = 리스트로 표현
            for (int barNo = 0; barNo < numOfBars; barNo++)
            {
                int barLength = int.Parse(Console.ReadLine()); // 막대기 길이
                // 길이, 인덱스+1 위치에 입력받은 길이의 막대기 생성
                List<int> newBar = InitializeBarWithValue(barLength, barNo + 1);
                barFromRight = AddBarAtLast(barFromRight, newBar); // 최우측 시점의 막대기 보기
            }
            List<int> result = new HashSet<int>(barFromRight).OrderByDescending(e=>e).ToList();

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join(", ",result.Select(i=>i.ToString())));
        }

        // 막대기 생성
        static List<int> InitializeBarWithValue(int barLength, int initialValue)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < barLength; i++)
            {
                result.Add(initialValue);
            }
            return result;
        }

        // 우측에서 보는 시점의 막대기 리스트 생성
        static List<int> AddBarAtLast(List<int> lastBar, List<int> addingBar)
        {
            List<int> resultBar;
            if (lastBar.Count >= addingBar.Count)
            {
                resultBar = new List<int>(lastBar);
                for (int i = 0; i < addingBar.Count; i++)
                {
                    resultBar[i] = addingBar[i];
                }
            }
            else
            {
                resultBar = new List<int>(addingBar);
            }
            return resultBar;
        }
    }
}
