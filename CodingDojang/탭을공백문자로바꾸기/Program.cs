using System;
using System.IO;

namespace CD019
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = @"c:\temp\source.txt";
                string convString = TAB2SPACE(File.ReadAllText(filename));
                File.WriteAllText(filename + ".converted.txt", convString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        static string TAB2SPACE(string aString) => aString.Replace("\t", "    ");
    }
}
