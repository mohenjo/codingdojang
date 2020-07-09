using System;
using System.Linq;

namespace CD011
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultMsg = String.Empty;
            // 각 라인 입력 받아 올림 연산 메세지 출력
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "0" && input[1] == "0") { break; }
                var newCarryOperation = new Carry(int.Parse(input[0]), int.Parse(input[1]));
                resultMsg += newCarryOperation.CarryMessage + Environment.NewLine;
            }
            Console.WriteLine(resultMsg);
        }
    }

    class Carry
    {
        readonly int[] NumA, NumB;

        public string CarryMessage // 올림 연산 수 표시 문자열
        {
            get
            {
                int result = NumCarry(NumA, NumB);
                string pre = (result == 0) ? "No" : result.ToString();
                string post = (result > 1) ? "s." : ".";
                return pre + " carry operation" + post;
            }
        }

        public Carry(int numA, int numB)
        {
            // int to array & sync array length
            NumA = numA.ToString().Select(c => (int)Char.GetNumericValue(c)).ToArray();
            NumB = numB.ToString().Select(c => (int)Char.GetNumericValue(c)).ToArray();
            int size = Math.Max(numA, numB).ToString().Length;
            Array.Reverse(NumA); Array.Reverse(NumB);
            Array.Resize(ref NumA, size); Array.Resize(ref NumB, size);
        }

        // 올림 연산의 수 계산
        static int NumCarry(int[] Arr1, int[] Arr2)
        {
            int numCarry = 0, overCarry = 0;
            for (int idx = 0; idx < Arr1.Length; idx++)
            {
                int tmpVal = Arr1[idx] + Arr2[idx] + overCarry;
                if (tmpVal >= 10)
                {
                    overCarry = (int)(tmpVal /10);
                    numCarry++;
                }
            }
            return numCarry;
        }
    }
}
