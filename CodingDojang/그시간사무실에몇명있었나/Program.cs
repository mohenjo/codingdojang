using System;
using System.Linq;
using System.IO;

namespace CD031
{
    class Program
    {
        static void Main()
        {
            string timeLog = File.ReadAllText(@"C:\temp\test.log"); // 로그파일 경로
            string checkTime = "11:05:20";

            int count = 0;
            foreach (var aLog in timeLog.Split('\n'))
            {
                var time = aLog.Trim().Split();
                if (IsBetween(time[0], time[1], checkTime)) { count++; }
            }
            Console.WriteLine(count);
        }

        static bool IsBetween(string beginTime, string endTime, string checkTime)
            => Time2Sec(beginTime) <= Time2Sec(checkTime) && Time2Sec(checkTime) <= Time2Sec(endTime);

        static int Time2Sec(string aString) // 시간 문자열을 초(int)로 변환
        {
            var time = aString.Split(':').Select(int.Parse).ToArray();
            return time[0] * 3600 + time[1] * 60 + time[2];
        }
    }
}
