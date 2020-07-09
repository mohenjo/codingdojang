using System;
using System.Text;

namespace CD233
{
    class Program
    {
        static void Main()
        {
            int angle = int.Parse(Console.ReadLine());

            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    for (int second = 0; second < 60; second++)
                    {
                        var CurrentTime = new ClockHands(hour, minute, second);
                        if (CurrentTime.GetAngleDifference() == angle)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append($"{hour.ToString().PadLeft(2,'0')}:");
                            sb.Append($"{minute.ToString().PadLeft(2,'0')}:");
                            sb.Append($"{second.ToString().PadLeft(2,'0')}");
                            Console.WriteLine(sb);
                        }
                    }
                }
            }
        }
    }

    class ClockHands
    {
        public int TimeInSeconds { get; }

        // 시침 각도 (00:00:00 기준)
        private double HourHandAngle => ((double)360 / 12 / 60 / 60 * TimeInSeconds) % 360;

        // 분침 각도 (00:00:00 기준)
        private double MinuteHandAngle => ((double)360 / 60 / 60 * TimeInSeconds) % 360;

        public ClockHands(int hour, int minute, int second)
        {
            TimeInSeconds = second + minute * 60 + hour * 60 * 60;
        }

        public double GetAngleDifference()
        {
            double difference = Math.Abs(HourHandAngle - MinuteHandAngle);
            return difference > 180 ? 360 - difference : difference;
        }
    }
}
