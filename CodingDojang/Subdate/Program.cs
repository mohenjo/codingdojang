using System;

namespace CD008
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SubDate("20070515 sub 20070501"));
            Console.WriteLine(SubDate("20070501 sub 20070515"));
            Console.WriteLine(SubDate("20070301 sub 20070515"));
        }

        static int SubDate(string aString)
        {
            string[] input = aString.Split();
            return Math.Abs(new CalDays(input[0]).Count() - new CalDays(input[2]).Count());
        }
    }

    // this.Count(): 그레고리력 시작년도부터의 일 수 반환
    class CalDays
    {
        readonly int Year, Month, Day;

        int[] _DaysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int[] DaysInMonth
        {
            get
            {
                if (IsYun(Year)) { _DaysInMonth[2] = 29; }
                return _DaysInMonth;
            }
        }

        public CalDays(string dateString)
        {
            Year = int.Parse(dateString.Substring(0, 4));
            Month = int.Parse(dateString.Substring(4, 2));
            Day = int.Parse(dateString.Substring(6, 2));
        }

        public int Count() // days from 1582 그레고리력 시작년도
        {
            int days = Day;
            for (int y = 1582; y < Year; y++)
            {
                days += DaysInYear(y);
            }
            for (int m = 1; m < Month; m++)
            {
                days += DaysInMonth[m];
            }
            return days;
        }

        static int DaysInYear(int year) => IsYun(year) ? 366 : 365;

        static bool IsYun(int year)
        {
            bool check = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
            return check ? true : false;
        }
    }
}
