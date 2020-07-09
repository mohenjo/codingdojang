using System;
class P
{
    static void Main()
    {
        string s = @"using System;
class P
{{
    static void Main()
    {{
        string s=@{0}{1}{0};
        Console.Write(s, '{0}', s);
    }}
}}
}}";
        Console.Write(s, '"', s);
    }
}