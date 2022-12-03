using System;
using System.Collections.Generic;
using System.Linq;
public static class Dec3
{
    public static string TotalPriority()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec3\Input3.txt").ToList();

        List<int> prioList = new List<int>();

        foreach(var line in input)
        {
            var first = line.Substring(0, (line.Length / 2)).ToList();
            var last = line.Substring((line.Length / 2), (line.Length / 2)).ToList();

            var c = first.Intersect(last).FirstOrDefault();

            if(c <= 90)
                prioList.Add(c - 38); 
            else
                prioList.Add(c - 96);
                
        }
        return "Totala prioriterings är: " + prioList.Sum();
    }

    public static string GroupOfThree()
    {

        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec3\Input3.txt").ToList();

        List<int> prioList = new List<int>();

        for(int i = 0; i < input.Count; i += 3)
        {
            var x = input[i].ToList().Intersect(input[i + 1].ToList()).Intersect(input[i + 2].ToList()).FirstOrDefault();

            if (x <= 90)
                prioList.Add(x - 38);
            else
                prioList.Add(x - 96);
        }

        return "Totala prioriterings för grupp av 3 är: " + prioList.Sum();
    }
}

