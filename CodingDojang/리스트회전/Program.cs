using System;
using System.Collections.Generic;
using System.Linq;

namespace CD014
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = Rotate(input);
            foreach (var val in result) { Console.Write($"{val} "); }
            Console.WriteLine();
        }

        static List<string> Rotate(string aString)
        { // 회전: Queue 클래스에서 dequeue -> enqueue (단, 문제에서의 방향과 반대임)
            // parse input
            var tmp = aString.Split().ToList();
            int rotate = int.Parse(tmp[0]);
            var q = new Queue<string>(tmp.GetRange(1, tmp.Count - 1));
            // rotate List
            int moveAmount = q.Count - rotate % q.Count;
            for (int repeat = 1; repeat <= moveAmount; repeat++) { q.Enqueue(q.Dequeue()); }
            return q.ToList();
        }
    }
}
