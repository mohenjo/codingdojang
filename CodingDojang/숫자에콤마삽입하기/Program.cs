using System;

namespace CD012
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ParseToCurrency(1000));
            Console.WriteLine(ParseToCurrency(20000000));
            Console.WriteLine(ParseToCurrency(-3245.24));
        }

        static string ParseToCurrency(double aNumber)
        {
            string head = String.Empty, body, tail = String.Empty;
            // 기호 부분 => head
            var aString = aNumber.ToString();
            if (aString[0] == '+' || aString[0] == '-')
            {
                head = new string(aString[0], 1);
                aString = aString.Substring(1);
            }
            // 소숫점 이하 => tail
            var aSplit = aString.Split(new char[] { '.' });
            tail = (aSplit.Length > 1) ? "." + aSplit[1] : string.Empty;
            // 숫자 몸통 => commarizedBody
            body = aSplit[0];
            string commarizedBody = string.Empty;
            for (int idx = 0; idx < body.Length; idx++)
            {
                if (idx != 0 && idx % 3 == 0) { commarizedBody = "," + commarizedBody; }
                commarizedBody = body[body.Length - idx - 1] + commarizedBody;
            }
            return head + commarizedBody + tail;
        }
    }
}
