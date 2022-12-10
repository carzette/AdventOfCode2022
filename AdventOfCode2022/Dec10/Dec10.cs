using System;
using System.Collections.Generic;
using System.Linq;
public static class Dec10
{
    public static string A()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec10\Input10.txt").ToList();

        var registerX = 1;
        var cycleCounter = 0;
        var totalSignalStrenght = 0;
        int[] specificCycle = { 20, 60, 100, 140, 180, 220 };
        foreach (var x in input)
        {
            if (x == "noop")
            {
                cycleCounter++;
                if (specificCycle.Contains(cycleCounter))
                {
                    totalSignalStrenght += registerX * cycleCounter;
                   // Console.WriteLine(registerX);
                }
            }
            else
            {
                cycleCounter++;
                if (specificCycle.Contains(cycleCounter))
                {
                    totalSignalStrenght += registerX * cycleCounter;
                }
                cycleCounter++;
                
                if (specificCycle.Contains(cycleCounter))
                {
                    totalSignalStrenght += registerX * cycleCounter;
                }
                registerX += int.Parse(x.Split(' ')[1]);
            }

        }
        return "Totala signalstyrkan är: " + totalSignalStrenght.ToString();
    }

    public static string B()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec10\Input10.txt").ToList();

        var registerX = 1;
        var cycleCounter = 0;
        var totalSignalStrenght = 0;
        int[] specificCycle = { 40, 80, 120, 160, 200, 240 };
        var currPos = 0;
        int[] spritePos = { registerX - 1, registerX, registerX + 1 };
        foreach (var x in input)
        {
            if (x == "noop")
            {
                cycleCounter++;
                if (spritePos.Contains(currPos))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
                currPos++;
                if (specificCycle.Contains(cycleCounter))
                {
                    Console.WriteLine("");
                    currPos = 0;
                    totalSignalStrenght += registerX * cycleCounter;
                }
            }
            else
            {
                cycleCounter++;
                if (spritePos.Contains(currPos))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
                currPos++;
                if (specificCycle.Contains(cycleCounter))
                {
                    Console.WriteLine("");
                    currPos = 0;
                    totalSignalStrenght += registerX * cycleCounter;
                }
                cycleCounter++;
                if (spritePos.Contains(currPos))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
                currPos++;

                if (specificCycle.Contains(cycleCounter))
                {
                    Console.WriteLine("");
                    currPos = 0;
                    totalSignalStrenght += registerX * cycleCounter;
                }
                registerX += int.Parse(x.Split(' ')[1]);
                spritePos[0] = registerX - 1;
                spritePos[1] = registerX;
                spritePos[2] = registerX + 1;
            }

        }
        return "Display: ";
    }

}