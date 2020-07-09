using System;
using System.Collections.Generic;

namespace CD161
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input 3 integers (ex 2, 5, 3): ");
            string[] input = Console.ReadLine().Split(',');
            Console.WriteLine($"=> {MidVal(input)}");
        }

        static int MidVal(string[] input)
        {
            var tmpLst = new List<int>();
            foreach (var str in input)
            {
                tmpLst.Add(int.Parse(str));
            }
            tmpLst.Sort();
            return tmpLst[1];
        }
    }
}
