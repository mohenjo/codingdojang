﻿using System;
using System.Text;

namespace CD220
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("지구가 기울어진 각도(degree): ");
            double axialTile = double.Parse(Console.ReadLine());
            Console.Write("위도(degree): ");
            double latitude = double.Parse(Console.ReadLine());

            DayNightRatio testCase = new DayNightRatio(axialTile, latitude);
            Console.WriteLine(testCase.ToString());
        }
    }

    public class DayNightRatio
    {
        private readonly double AxialTilt;

        private readonly double Latitude;

        public DayNightRatio(double axialTilt, double latitude) // 각도(Degree) 단위 입력
        {
            AxialTilt = axialTilt;
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

        private static double ToRad(double degree) => 2 * Math.PI / 360 * degree;

        private static double ToDeg(double rad) => 360 / (2 * Math.PI) * rad;
    }
}
