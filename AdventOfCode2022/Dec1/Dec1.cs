using System;
using System.Collections.Generic;
using System.Linq;
public static class Dec1
{
    public static string HighestKCal()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec1\Input1.txt").ToList();

        List<int> elfList = new List<int>();
        int elf = 0;
        foreach(var e in input)
        {
            if (e != "")
            {
                elf += int.Parse(e);
            }
            else
            {
                elfList.Add(elf);
                elf = 0;
            }
        }
        return "Högst är: " + elfList.Max();
    }

    public static string HighestThree()
    {

        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec1\Input1.txt").ToList();

        List<int> elfList = new List<int>();
        int elf = 0;
        foreach (var e in input)
        {
            if (e != "")
            {
                elf += int.Parse(e);
            }
            else
            {
                elfList.Add(elf);
                elf = 0;
            }
        }
        elfList.Sort();
        var end = elfList.Count;
        return "Högsta 3 är: " + (elfList[end-1] + elfList[end - 2] + elfList[end - 3]);
    }
}

