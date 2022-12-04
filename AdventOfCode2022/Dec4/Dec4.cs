using System;
using System.Collections.Generic;
using System.Linq;
public static class Dec4
{
    public static string IntersectedPairs()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec4\Input4.txt").ToList();

        int intersectedCounter = 0;

        foreach(var line in input)
        {
            var pairs = line.Split(',');
            var firstPair = pairs[0].Split("-");
            var secondPair = pairs[1].Split("-");

            var firstPairArray = Enumerable.Range(int.Parse(firstPair[0]), int.Parse(firstPair[1]) - int.Parse(firstPair[0]) +1);
            var secondPairArray = Enumerable.Range(int.Parse(secondPair[0]), int.Parse(secondPair[1]) - int.Parse(secondPair[0]) + 1);

            if((firstPairArray.Contains(secondPairArray.Max()) && firstPairArray.Contains(secondPairArray.Min())) || (secondPairArray.Contains(firstPairArray.Max()) && secondPairArray.Contains(firstPairArray.Min())))
                intersectedCounter ++;

        }
        return "Totala par som intersectar är: " + intersectedCounter;
    }

    public static string IntersectedABitPairs()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec4\Input4.txt").ToList();

        int intersectedCounter = 0;

        foreach (var line in input)
        {
            var pairs = line.Split(',');
            var firstPair = pairs[0].Split("-");
            var secondPair = pairs[1].Split("-");

            var firstPairArray = Enumerable.Range(int.Parse(firstPair[0]), int.Parse(firstPair[1]) - int.Parse(firstPair[0]) + 1);
            var secondPairArray = Enumerable.Range(int.Parse(secondPair[0]), int.Parse(secondPair[1]) - int.Parse(secondPair[0]) + 1);

            if ((firstPairArray.Contains(secondPairArray.Max()) || firstPairArray.Contains(secondPairArray.Min())) || (secondPairArray.Contains(firstPairArray.Max()) || secondPairArray.Contains(firstPairArray.Min())))
                intersectedCounter++;

        }
        return "Totala par som intersectar är: " + intersectedCounter;
    }
}

