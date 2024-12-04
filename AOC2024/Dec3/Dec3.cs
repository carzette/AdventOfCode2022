
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public static class Dec3
{
    public static string A()
    {
        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec3\Input3.txt").ToList();
        var testInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var totalSum = 0;

        foreach (var line in input)
        {
            MatchCollection matches = Regex.Matches(line, pattern);
            
            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                totalSum += x * y;
            }
        }



        return "total added up of mul is: " + totalSum;
    }

    public static string B()
    {

        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec3\Input3.txt").ToList();
        var testInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";


        testInput = string.Join("", input);

        string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        int? totalSum = 0;

        List<Statement> statements = new List<Statement>();

        for(int i = 0; i <testInput.Length-8; i++)
        {
            if (testInput[i] == 'd' && testInput.Substring(i,(i+6)- i+1) == "don't()")
            {
                statements.Add(new Statement(i, i+6, "Dont",null));
            }
            else if (testInput[i] == 'd' && testInput.Substring(i, (i + 3) - i + 1) == "do()")
            {
                statements.Add(new Statement(i, i + 3, "Do", null));
            }
        }
        MatchCollection matchesMul = Regex.Matches(testInput, mulPattern);

        foreach (Match match in matchesMul)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                int startIndex = match.Index;
                int endIndex = match.Index + match.Length - 1;
                statements.Add(new Statement(startIndex, endIndex, "Mul", x * y));
            }



        var sortedStatements = statements.OrderBy(s => s.StartIndex).ToList();
        bool doTheMath = true;
        foreach(var s in sortedStatements)
        {
            if(s.Command == "Dont")
                doTheMath = false;
            if (s.Command == "Do" && doTheMath == false)
                doTheMath = true;

            if (doTheMath && s.Value != null)
            {
                totalSum+= s.Value;
            }

        }

        return "total added up of mul is: " + totalSum;
    }


}

public class Statement
{
    public string Command { get; set; }

    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public int? Value { get; set; }

    public Statement(int start, int end, string command, int? value)
    {
        StartIndex = start;
        EndIndex = end;
        Value = value;
        Command = command;
        
    }
}

