using System;
using System.Collections.Generic;
using System.Linq;
public static class Dec1
{
    public static string A()
    {
        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec1\Input1.txt").ToList();

        var leftNumbers = input
           .Select(line => int.Parse(line.Split("   ")[0])).ToArray();
        var rightNumbers = input
        .Select(line => int.Parse(line.Split("   ")[1])).ToArray();

        Array.Sort(leftNumbers);
        Array.Sort(rightNumbers);


        var totaldiff = 0;

        for(int i = 0; i < input.Count(); i++)
        {
            totaldiff += Math.Abs(leftNumbers[i] - rightNumbers[i]);
            //Console.WriteLine(Math.Abs(leftNumbers[i] - rightNumbers[i]));
        }

        return "total distance: " + totaldiff;
    }

    public static string B()
    {

        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec1\Input1.txt").ToList();
        var leftNumbers = input
   .Select(line => int.Parse(line.Split("   ")[0])).ToArray();
        var rightNumbers = input
        .Select(line => int.Parse(line.Split("   ")[1])).ToArray();

        var retVal = 0;
        foreach(var n in leftNumbers)
        {
            retVal += n * rightNumbers.Count(x => x == n);
        }

        return "similar score: " + retVal;
    }
}

