using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec7Take2
{
    public static string A()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec7\Input72.txt").ToList();

        var dirPath = new List<string>();
        var files = new List<(string Path, string Name, int Size)>();

        foreach (var line in input.Where(x => x != "$ ls"))
        {
            if (line.Contains(".."))
                dirPath.Remove(dirPath.Last());
            else if (line.StartsWith("$ cd"))
                dirPath.Add(line.Split(" ")[2]);
            else if (line.Contains("dir"))
                files.Add((string.Join("/", dirPath) + "/" + line.Split(" ")[1], "not a file", 0));
            else
                files.Add((string.Join("/", dirPath), line.Split(" ")[1], int.Parse(line.Split(" ")[0])));
        }

        var folders = files.Select(p => p.Path).Select(x => (Name: x, Size: files.Where(y => y.Path.StartsWith(x)).Sum(y => y.Size))).Distinct().ToArray();

        var result = folders.Where(dir => dir.Size < 100000).Sum(s => s.Size);


        return "Total värde av alla med size max 100 000: " + result.ToString();
    }
    public static string B()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec7\Input72.txt").ToList();

        var dirPath = new List<string>();
        var files = new List<(string Path, string Name, int Size)>();

        foreach (var line in input.Where(x => x != "$ ls"))
        {
            if (line.Contains(".."))
                dirPath.Remove(dirPath.Last());
            else if (line.StartsWith("$ cd"))
                dirPath.Add(line.Split(" ")[2]);
            else if (line.Contains("dir"))
                files.Add((string.Join("/", dirPath) + "/" + line.Split(" ")[1], "not a file", 0));
            else
                files.Add((string.Join("/", dirPath), line.Split(" ")[1], int.Parse(line.Split(" ")[0])));
        }

        var folders = files.Select(p => p.Path).Select(x => (Name: x, Size: files.Where(y => y.Path.StartsWith(x)).Sum(y => y.Size))).Distinct().ToArray();
        //var sortedFolders = folders.OrderByDescending(d => d.Size).ToArray();
        var occupiedSpace = double.Parse(folders.OrderByDescending(d => d.Size).ToArray().First().Size.ToString());
        var reqSpace = 30000000;
        var totSpace = 70000000;
        var spaceToRemove = reqSpace - (totSpace - occupiedSpace);
        
        var listOfPotentialRemovers = folders.Where(x => x.Size >= spaceToRemove).OrderByDescending(d => d.Size).Last(); ;

        return "Värdet av minsta directory som man tagit bort för att nå upp i spaceLeft: ";
    }
}
