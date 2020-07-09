using System;

namespace CD042
{
    class Program
    {
        static void Main()
        {
            string result = string.Empty;
            while (true)
            {
                uint numLights = uint.Parse(Console.ReadLine());
                if (numLights == 0) { break; }
                result += Environment.NewLine + LastLightStatus(numLights);
            }
            Console.WriteLine(result);
        }

        static string LastLightStatus(uint numLights)
        {
            bool lightStatus = false;
            for (uint way = 1; way <= numLights; way++)
            {
                if (numLights % way == 0) { lightStatus = !lightStatus; }
            }
            return lightStatus == true ? "yes" : "no";
        }
    }
}
