using System;
using System.Collections.Generic;
using System.Linq;

namespace CD100
{
    class Program
    {
        static void Main()
        {
            // 입력 자료 구성
            StockValue[] sampleData = 
            {
                new StockValue("1:02, 1100"), new StockValue("1:20, 1170"), new StockValue("1:59, 1090"),
                new StockValue("2:30, 1030"), new StockValue("2:31, 1110"), new StockValue("2:42, 1150"),
                new StockValue("2:55, 1210"), new StockValue("2:56, 1190"), new StockValue("3:02, 1120"),
                new StockValue("3:09, 1100"), new StockValue("4:15, 1090"), new StockValue("4:20, 1080"),
                new StockValue("4:55, 1050"), new StockValue("4:56, 1020"), new StockValue("4:57, 1000")
            };

            // 입력 자료 정렬 후, 분에 따라 데이터 그룹화: (key = 분, 해당 분에 속하는 StockValue 인스턴스들)
            var filterByMin = sampleData.OrderBy(sv => sv.Minute).ThenBy(sv => sv.Second)
                .GroupBy(grp => grp.Minute);

            var open = new List<int>();
            var high = new List<int>();
            var low = new List<int>();
            var close = new List<int>();
            foreach (var record in filterByMin) // 각 key(분) 별로
            {
                open.Add(record.First().Price); // 인스턴스 첫 값의 가격
                high.Add(record.Select(sv => sv.Price).Max()); // 인스턴스 가격 컬렉션의 최대값
                low.Add(record.Select(sv => sv.Price).Min()); // 인스턴스 가격 컬렉션의 최소값
                close.Add(record.Last().Price); // 인스턴스 마지막 값의 가격
            }

            // 결과 출력
            Console.WriteLine($"open = [{string.Join(", ", open)}]");
            Console.WriteLine($"high = [{string.Join(", ", high)}]");
            Console.WriteLine($"low = [{string.Join(", ", low)}]");
            Console.WriteLine($"close = [{string.Join(", ", close)}]");
        }
    }

    class StockValue
    {
        public int Minute { get; } = 0;
        public int Second { get; } = 0;
        public int Price { get; } = 0;

        public StockValue(string aRecord) // "분:초, 가격" 문자열로부터 인스턴스 생성
        {
            string[] splitedRecord = aRecord.Split(',');
            Price = int.Parse(splitedRecord[1]);
            int[] recordTime = splitedRecord[0].Split(':').Select(s => int.Parse(s)).ToArray();
            Minute = recordTime[0];
            Second = recordTime[1];
        }
    }
}
