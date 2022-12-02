using System;
using System.Collections.Generic;
using System.Linq;

// A och X = Rock
// B och Y = Paper
// C och Z = Scissor
public enum Player
{
    X = 0, 
    Y = 1, 
    Z = 2
}
public enum Elf
{
    A = 0,
    B = 1,
    C = 2
}
public enum Score
{
    W = 6,
    D = 3,
    L = 0
}
// rock paper scissor
//rock
//paper
//Scissor
public static class Dec2
{
    public static string TotalScore()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec2\Input2.txt").ToList();
        char[,] results = 
        {
        { 'D', 'L', 'W' }, 
        { 'W', 'D', 'L' },
        { 'L', 'W', 'D' }
        };
        int totalScore = 0;
        int roundScore = 0;
        foreach (var e in input)
        {
            var eMove = (int)Enum.Parse(typeof(Elf), e[0].ToString());
            var pMove = (int)Enum.Parse(typeof(Player), e[2].ToString());
            
            var roundResult = (int)Enum.Parse(typeof(Score), results[pMove, eMove].ToString());
          
            roundScore = roundResult + pMove + 1;
            totalScore += roundScore;

        }
        return "Total score is: " + totalScore;
    }

    public static string CorrectTotalScore()
    {
        // X = Lose, Y = Draw, Z = Win
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec2\Input2.txt").ToList();
        char[,] results =
        {
        { 'D', 'L', 'W' },
        { 'W', 'D', 'L' },
        { 'L', 'W', 'D' }
        };
        int totalScore = 0;
        int roundScore = 0;
        foreach (var e in input)
        {
            var eMove = (int)Enum.Parse(typeof(Elf), e[0].ToString());
            var pMove = 0;

            if (e[2] == 'X')
            {
                if (eMove - 1 >= 0)
                    pMove = eMove - 1;
                else
                    pMove = 2;
            }

            else if (e[2] == 'Y')
                pMove = eMove;

            else
            {
                if (eMove + 1 <= 2)
                    pMove = eMove + 1;
                else
                    pMove = 0;
            }

            var roundResult = (int)Enum.Parse(typeof(Score), results[pMove, eMove].ToString());

            roundScore = roundResult + pMove + 1;
            totalScore += roundScore;

        }
        return "Correct Total score is: " + totalScore;
    }
}

