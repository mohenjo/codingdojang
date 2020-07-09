using System;
using System.Linq;

namespace CD189
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] triangle;
            triangle = new int[] { 60, 60, 60 };
            Console.WriteLine(GetTriangleType(triangle));
            triangle = new int[] { 30, 60, 90 };
            Console.WriteLine(GetTriangleType(triangle));
            triangle = new int[] { 20, 40, 120 };
            Console.WriteLine(GetTriangleType(triangle));
            triangle = new int[] { 0, 90, 90 };
            Console.WriteLine(GetTriangleType(triangle));
            triangle = new int[] { 60, 70, 80 };
            Console.WriteLine(GetTriangleType(triangle));
            triangle = new int[] { 40, 40, 50, 50 };
            Console.WriteLine(GetTriangleType(triangle));
        }

        static string GetTriangleType(int[] anArray)
        {
            string result = String.Empty;
            if (IsTriangle(anArray))
            {
                result = AngleType(anArray.Max());
            }
            else
            {
                result = "삼각형이 아니다.";
            }
            return result;
        }

        static bool IsTriangle(int[] anArray) 
            => anArray.Min() > 0 && anArray.Length == 3 && anArray.Sum() == 180;

        static string AngleType(int anAngle)
        {
            string result = string.Empty;
            if (anAngle < 90)
            {
                result = "예각삼각형";
            }
            else if (anAngle > 90)
            {
                result= "둔각삼각형";
            }
            else
            {
                result = "직각삼각형";
            }
            return result;
        }
    }
}
