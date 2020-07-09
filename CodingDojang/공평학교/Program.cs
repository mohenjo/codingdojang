using System;
using System.Collections.Generic;

namespace CD178
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1();
            Problem2();
        }

        // 입력 인자 수 만큼의 학생 순서 랜덤 반환
        static List<int> StudentsInLine(int aNumberOfStudents)
        {
            var order = new HashSet<int>();
            var random = new Random();
            while (order.Count < aNumberOfStudents)
            {
                order.Add(random.Next(1, aNumberOfStudents + 1));
            }
            return new List<int>(order);
        }

        static void Problem1() // 문제1
        {
            Console.Write("학생 수: ");
            int numOfStudent = int.Parse(Console.ReadLine());
            if (numOfStudent > 1000000) return;

            foreach (var val in StudentsInLine(numOfStudent))
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
        }

        static void Problem2() // 문제2
        {
            Console.Write("학생 수(A), 가로줄 당 학생 수(B): ");
            string input = Console.ReadLine();
            int numOfStudent = int.Parse(input.Split()[0]);
            int numOfStudentPerLine = int.Parse(input.Split()[1]);

            var students = StudentsInLine(numOfStudent);
            for (int i = 0; i < students.Count; i++)
            {
                Console.Write($"{students[i],5} ");
                if (i % numOfStudentPerLine == numOfStudentPerLine - 1) { Console.WriteLine(); }
            }
            Console.WriteLine();
        }
    }
}
