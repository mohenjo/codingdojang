using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CD018
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDir = @"D:\OneDrive\Storage\Docs";
            string extFilter = "*.txt";
            string checkString = ".exe";
            foreach (var e in GetFileList(startDir, extFilter, checkString))
            {
                Console.WriteLine(e);
            }
        }
        static List<string> GetFileList(string startDir, string extFilter, string checkString)
        {
            List<string> result = new List<string>();

            try
            {
                result = Directory.EnumerateFiles(startDir, extFilter, SearchOption.AllDirectories)
                    .Where(f => File.ReadAllText(f).Contains(checkString)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return result;
        }
    }
}
