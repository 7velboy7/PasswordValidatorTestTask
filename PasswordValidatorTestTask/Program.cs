using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("enter the path of txt file");
        string? pathToTheFile = Console.ReadLine();
        int validPasswords = 0; 

        using (StreamReader sr = new StreamReader(pathToTheFile))
        {
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                string pattern = @"(.) (\d+)-(\d+): (.*)";

                Match match = Regex.Match(line, pattern);

                char requiredChar = match.Groups[1].Value[0];
                int min = int.Parse(match.Groups[2].Value);
                int max = int.Parse(match.Groups[3].Value);
                string password = match.Groups[4].Value;

                int count = 0;
                foreach (char c in password)
                {
                    if (c == requiredChar)
                    {
                        count++;
                    }
                }

                if (count >= min && count <= max)
                {
                    validPasswords++;
                }
            }
        }

        Console.WriteLine($"the quantity of valid passwords: {validPasswords}");
        Console.ReadLine();
    }
}
