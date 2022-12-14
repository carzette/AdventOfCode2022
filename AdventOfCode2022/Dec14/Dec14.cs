using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Text;
using System.Diagnostics;
public static class Dec14
{
    public static string AB(string part)
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec14\Input14.txt").Select(x => x.Split("->")).ToList().ToList();

        var min1 = input.SelectMany(i => i).Distinct().Min( x => double.Parse(x));
        var max1 = input.SelectMany(i => i).Distinct().Max(x => double.Parse(x));

        var maxNumber = 0;
        foreach(var i in input)
        {
            foreach(var s in i)
            {
                var value = int.Parse(s.Split(',')[1].ToString());
                if(value > maxNumber)
                    maxNumber = value;

            }
        }

        var gridWStart = int.Parse(min1.ToString().Split(',')[0])-250;
        var gridW = int.Parse(max1.ToString().Split(',')[0]) + 250;
        
        var gridH = maxNumber + 3;
        
        var grid = new char[gridH, gridW];
        grid[0,500] = '+';
        
        for(int i = 0; i < gridH; i++)
        {
            for (int j = gridWStart; j < gridW; j++)
            {
                if(grid[i, j] != '+')
                    grid[i, j] = '.';
                
                if(part == "2")
                {
                    if(i == gridH - 1)
                        grid[i, j] = '#';
                }
            }
        }
        //-----------------------
        for ( int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length-1; j++)
            {
                grid = drawLine(grid, input[i][j], input[i][j+1]);
            }
        }
        //-----------------------
        //add sand
        var sandCounter = 0;
        var abyss = false;

        while (!abyss)
        {
            var sandStuck = false;
            var curtPosY = 0;
            var curtPosX = 500;
            
            while (!sandStuck)
            {
                if(grid[curtPosY, curtPosX] == 'O')
                {
                    abyss = true;
                    break;
                }
                if (grid[curtPosY+1, curtPosX] == '#' || grid[curtPosY + 1, curtPosX] == 'O')
                {
                    if(grid[curtPosY + 1, curtPosX-1] == '#' || grid[curtPosY + 1, curtPosX-1] == 'O')
                    {
                        if (grid[curtPosY + 1, curtPosX + 1] == '#' || grid[curtPosY + 1, curtPosX + 1] == 'O')
                        {
                            sandStuck = true;
                            break;
                        }
                        else 
                        {
                            curtPosY++;
                            curtPosX++;
                        }
                    }
                    else
                    {
                        curtPosY++;
                        curtPosX--;
                    }
                }
                else
                {
                    curtPosY++;
                }

                if(part == "1")
                {
                    if (curtPosY >= gridH - 1)
                    {
                        abyss = true;
                        break;
                    }
                }

            }
            if (!abyss)
            {
                grid[curtPosY, curtPosX] = 'O';
                sandCounter++;

            }

        }

        return "13: " + sandCounter;
    }
    public static char[,] drawLine(char[,] currGrid, string fromPos, string toPos)
    {
        var grid = currGrid;

        var fromX = int.Parse(fromPos.Split(',')[0]);
        var fromY = int.Parse(fromPos.Split(',')[1]);
        var toX = int.Parse(toPos.Split(',')[0]);
        var toY = int.Parse(toPos.Split(',')[1]);

        var startPosY = Math.Min(fromY, toY);
        var startPosX = Math.Min(fromX, toX);

        var endPosY = Math.Max(fromY, toY);
        var endPosX = Math.Max(fromX, toX);

        for (int i = startPosY; i <= endPosY; i++)
        {
            for (int j = startPosX; j <= endPosX; j++)
            {
                grid[i, j] = '#';
            }
        }
        return grid;
    }


}
