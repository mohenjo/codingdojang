using System;
using System.Text;

namespace CD222
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("월(month): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("일(day): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("위도(degree): ");
            double latitude = double.Parse(Console.ReadLine());

            DayNightRatio testCase = new DayNightRatio(month, day, latitude);
            Console.WriteLine(testCase.ToString());
        }
    }

    public class DayNightRatio
    {
        private readonly double AxialTilt;
        private readonly double Latitude;

        // 자전축 각도가 주어질 경우
        public DayNightRatio(double axialTilt, double latitude) // 각도(Degree) 단위 입력
        {
            AxialTilt = axialTilt;
            Latitude = latitude;
        }

        // 월, 일이 주어질 경우
        public DayNightRatio(int month, int day, double latitude) // 각도(Degree) 단위 입력
        {
            AxialTilt = DateToAxialTilt(month, day);
            Latitude = latitude;
        }

        private double NightRatio()
        {
            if (Math.Abs(AxialTilt) > 90 - Math.Abs(Latitude))
            {
                return AxialTilt * Latitude >= 0 ? 0 : 1;
            }
            double theta3Rad =
                Math.Acos(Math.Tan(ToRad(AxialTilt)) * Math.Tan(ToRad(Latitude)));
            return 2 * ToDeg(theta3Rad) / 360;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double ratio = NightRatio();
            if (ratio == 0)
            {
                sb.AppendLine("계속 낮입니다.");
            }
            else if (ratio == 1)
            {
                sb.AppendLine("계속 밤입니다.");
            }
            else
            {
                TimeSpan nightTime = TimeSpan.FromSeconds(60 * 60 * 24 * ratio);
                TimeSpan dayTime = TimeSpan.FromSeconds(60 * 60 * 24 * (1 - ratio));
                sb.AppendLine($"낮의 길이 {dayTime.ToString()}");
                sb.AppendLine($"밤의 길이 {nightTime.ToString()}");
            }
            return sb.ToString();
        }

        // 월, 일로부터 자전축 기울기 계산
        private static double DateToAxialTilt(int month, int day)
        {
            // 평년(2019)년 기준으로 일차 계산
            DateTime winterSolsticeDate = new DateTime(2019, 12, 22);
            DateTime checkDate = new DateTime(2019, month, day);
            int timeSpan = (checkDate - winterSolsticeDate).Days;
            timeSpan = timeSpan < 0 ? 365 + timeSpan : timeSpan;

            double axialTilt = timeSpan <= (double)365 / 2 ?
                (double)94 / 365 * timeSpan - 23.5 :
                -(double)94 / 365 * timeSpan + 70.5;
            return axialTilt;
        }

        private static double ToRad(double degree) => 2 * Math.PI / 360 * degree;

        private static double ToDeg(double rad) => 360 / (2 * Math.PI) * rad;
    }
}
