using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec8
{
    public static string A()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec8\Input82.txt").ToList();


        var grid = new int[input.Count(), input.Count()];
        for (int i = 0; i < input.Count(); i++)
        {
            //Console.WriteLine("");
            for (int j = 0; j < input.Count(); j++)
            {
                var x = input[i][j].ToString();
                grid[i, j] = int.Parse(x);
                //Console.Write(x);
            }
        }


        var visibleTrees = (input.Count() * 2) + ((input.Count() - 2) * 2);

        for(int i = 1; i < input.Count() - 1; i++)
        {
            
            for (int j = 1; j < input.Count() -1 ; j++)
            {
                //Console.WriteLine("Kollar på: " + "y: " + i + " ,x: " + j);
                if (CanSeeFromDir(j, i, "top", grid) || CanSeeFromDir(j, i, "bot", grid) || CanSeeFromDir(j, i, "left", grid) || CanSeeFromDir(j, i, "right", grid))
                    visibleTrees++;
            }
        }

        return "Träd som är synliga: " + visibleTrees.ToString();
    }
    public static bool CanSeeFromDir(int x, int y, string dir, int[,] grid)
    {
        bool visible = true;
        if(dir == "top")
        {
            for (int i = y-1; i >= 0; i--)
            {
                if (grid[i,x] >= grid[y, x])
                {
                    visible = false;
                    return visible;
                }

            }
        }
        else if(dir == "bot")
        {
            for (int i = y + 1; i < Math.Sqrt(grid.Length); i++)
            {
                if (grid[i, x] >= grid[y, x])
                {
                    visible = false;
                    return visible;
                }

            }
        }
        else if (dir == "left")
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (grid[y, i] >= grid[y, x])
                {
                    visible = false;
                    return visible;
                }

            }
        }
        else
        {
            for (int i = x + 1; i < Math.Sqrt(grid.Length); i++)
            {
                if (grid[y, i] >= grid[y, x])
                {
                    visible = false;
                    return visible;
                }

            }
        }
        return true;
    }

    public static string B()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec8\Input82.txt").ToList();


        var grid = new int[input.Count(), input.Count()];
        for (int i = 0; i < input.Count(); i++)
        {
            for (int j = 0; j < input.Count(); j++)
            {
                var x = input[i][j].ToString();
                grid[i, j] = int.Parse(x);
            }
        }

        var trees = new List<int>();
        for (int i = 1; i < input.Count() - 1; i++)
        {

            for (int j = 1; j < input.Count() - 1; j++)
            {
                trees.Add(GetTreeScore(j,i,grid));

            }
        }

        return "Träd som är synliga: " + trees.Max().ToString();
    }
    public static int GetTreeScore(int x, int y, int[,] grid)
    {
        
        var scoreTop = 0; 
        var scoreBottom = 0;
        var scoreLeft = 0;
        var scoreRight = 0;
        if (true)//top
        {
            for (int i = y - 1; i >= 0; i--)
            {
                if (grid[i, x] < grid[y, x])
                {
                    scoreTop++;

                }
                else if (grid[i, x] >= grid[y, x]) 
                {
                    scoreTop++;
                    break;
                }
                

            }
        }
        if (true)//bot
        {
            for (int i = y + 1; i < Math.Sqrt(grid.Length); i++)
            {
                if (grid[i, x] < grid[y, x])
                {
                    scoreBottom++;

                }
                else if (grid[i, x] >= grid[y, x])
                {
                    scoreBottom++;
                    break;
                }
                   

            }
        }
        if (true)//left
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (grid[y, i] < grid[y, x])
                {
                    scoreLeft++;

                }
                else if (grid[y, i] >= grid[y, x])
                {
                    scoreLeft++;
                    break;
                }
                   

            }
        }
        if(true) //right
        {
            for (int i = x + 1; i < Math.Sqrt(grid.Length); i++)
            {
                if (grid[y, i] < grid[y, x])
                {
                    scoreRight++;

                }
                else if (grid[y, i] >= grid[y, x])
                {
                    scoreRight++;
                    break;
                }
                   

            }
        }
        int score = scoreBottom*scoreTop*scoreLeft*scoreRight;
        return score;
    }
}

