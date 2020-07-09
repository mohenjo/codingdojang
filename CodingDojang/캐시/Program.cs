using System;
using System.Collections.Generic;

namespace CD152
{
    class Program
    {
        static void Main()
        {
            int cacheSize;
            List<string> cities;

            cacheSize = 3;
            cities = new List<string>()
            { "Jeju", "Pangyo", "Seoul", "NewYork", "LA", "Jeju", "Pangyo", "Seoul", "NewYork", "LA" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            cacheSize = 3;
            cities = new List<string>()
            { "Jeju", "Pangyo", "Seoul", "Jeju", "Pangyo", "Seoul", "Jeju", "Pangyo", "Seoul" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            cacheSize = 2;
            cities = new List<string>()
            { "Jeju", "Pangyo", "Seoul", "NewYork", "LA", "SanFrancisco", "Seoul", "Rome", "Paris", "Jeju",
                "NewYork", "Rome" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            cacheSize = 5;
            cities = new List<string>()
            { "Jeju", "Pangyo", "Seoul", "NewYork", "LA", "SanFrancisco", "Seoul", "Rome", "Paris", "Jeju",
                "NewYork", "Rome" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            cacheSize = 2;
            cities = new List<string>() { "Jeju", "Pangyo", "NewYork", "newyork" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            cacheSize = 0;
            cities = new List<string>() { "Jeju", "Pangyo", "Seoul", "NewYork", "LA" };
            Console.WriteLine(Cache.GetProcessTime(cacheSize, cities));

            Console.ReadKey();
        }
    }
}
