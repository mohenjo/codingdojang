using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CD205
{
    class Program
    {
        static void Main()
        {
            // read text from file
            string inputFileName = Environment.CurrentDirectory + @"\input.txt";
            string[] inputText =
                File.ReadAllText(inputFileName)
                .Split(' ', '.', ',').Select(s => s.Trim()).Where(e => e.Length > 0).ToArray();

            // count each word
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var s in inputText)
            {
                if (wordCount.ContainsKey(s)) { wordCount[s] += 1; }
                else { wordCount[s] = 1; }
            }

            // display result 
            StringBuilder sb = new StringBuilder();
            var result = from pair in wordCount orderby pair.Value descending select pair;
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
