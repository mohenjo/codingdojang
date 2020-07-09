using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CD205AltOOP
{
    class Program
    {
        static void Main()
        {
            string aFileName = @"\input.txt";
            var altCase = new WordCount(new InputFile(aFileName).ContentsArray);
            altCase.DisplayTop10();
        }
    }

    sealed class InputFile // 입력 파일 핸들링을 위한 클래스 
    {
        private readonly string inputFileName;

        public InputFile(string aFileName)
        {
            inputFileName = Environment.CurrentDirectory + aFileName;
        }

        // 텍스트 파일의 각 단어 요소를 배열
        public string[] ContentsArray => File.ReadAllText(inputFileName)
                    .Split(' ', '.', ',').Select(s => s.Trim()).Where(e => e.Length > 0).ToArray();
    }

    sealed class WordCount // 텍스트 배열에 대한 단어 카운트 클래스
    {
        private readonly string[] stringArray; // 입력 텍스트 배열

        public WordCount(string[] aStringArray)
        {
            stringArray = aStringArray;
        }

        // 텍스트 배열 구성 단어 전체에 대한 카운트 쌍(단어 - 빈도)
        private Dictionary<string, int> WordCountPair
        {
            get
            {
                Dictionary<string, int> count = new Dictionary<string, int>();
                foreach (var s in stringArray)
                {
                    if (count.ContainsKey(s)) { count[s] += 1; }
                    else { count[s] = 1; }
                }
                return count;
            }
        }

        public void DisplayTop10() // 정렬 및 상위 10개 출력
        {
            StringBuilder sb = new StringBuilder();
            var result = from pair in WordCountPair orderby pair.Value descending select pair;
            int displayCount = 0;
            foreach (var pair in result)
            {
                sb.AppendLine($"{pair.Key} {pair.Value}");
                if (++displayCount >= 10) { break; }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
