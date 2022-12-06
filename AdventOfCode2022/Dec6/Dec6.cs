using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec6
{
    public static string FirstFourSequence()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec6\Input6.txt").ToList();
        var inputString = input.First();

        for (int i = 0; i < inputString.Length-4; i++)
        {
            if (inputString.Substring(i, 4).Distinct().ToList().Count() == 4)
                return "Första sekvensen där 4 är olka är på index: " + (i + 4).ToString() ;
        }

        return "No sequence was found! ";
    }

    public static string FirstFourteenSequence()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec6\Input6.txt").ToList();
        var inputString = input.First();

        for (int i = 0; i < inputString.Length - 15; i++)
        {
            if (inputString.Substring(i, 14).Distinct().ToList().Count() == 14)
                return "Första sekvensen där 15 är olka är på index: " + (i + 14).ToString();
        }

        return "No sequence was found! ";
    }
}

