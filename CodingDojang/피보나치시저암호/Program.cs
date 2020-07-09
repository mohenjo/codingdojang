using System;
using System.Collections.Generic;

namespace CD198
{
    class Program
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            string aString = Console.ReadLine();
            Console.WriteLine(EncryptString(aString, key));
        }

        static string EncryptString(string aString, int key) 
        {
            List<char> Encrypted = new List<char>();
            int fib = 1, nextFib = key;
            foreach (var s in aString)
            {
                if (Char.IsUpper(s))
                {
                    int newChar = s + fib % ('Z' - 'A' + 1);
                    newChar = newChar > 'Z' ? newChar - 'Z' + 'A' - 1 : newChar;
                    Encrypted.Add((char)newChar);

                    int tmpFib = fib + nextFib;
                    fib = nextFib; nextFib = tmpFib;
                }
                else { Encrypted.Add(s); }
            }
            return new String(Encrypted.ToArray());
        }
    }
}
