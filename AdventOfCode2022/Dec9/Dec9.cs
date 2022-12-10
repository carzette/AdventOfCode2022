using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec9
{
    public static string A()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec9\Input92.txt").ToList();

        var placesVisited = new List<(int x, int y)>();
        placesVisited.Add((0,0));
        var head = new RopeKnot(0, 0);
        var tail = new RopeKnot(0, 0);

        var moveDir = "";
        var moveNum = 0;
        foreach(var c in input)
        {
            //Console.WriteLine(c);
            moveDir = c.Split(' ')[0];
            moveNum = int.Parse(c.Split(' ')[1]);

            for(int i = 0; i < moveNum; i++)
            {
                if(moveDir == "U")
                {
                    head.Y++;
                    if (tail.X == head.X) //samma bredd
                    {
                        if (tail.Y+1 < head.Y) //T under H
                            tail.Y++;
                        else if (tail.Y == head.Y || tail.Y+1 == head.Y)
                        {//do Noting with tail
                        }

                    }
                    else if(tail.Y == head.Y-2 && tail.X == head.X-1)//T snett vänster under H
                    {
                        tail.Y++;
                        tail.X++;
                    }
                    else if (tail.Y == head.Y -2&& tail.X == head.X+1)////T snett höger under H
                    {
                        tail.Y++;
                        tail.X--;
                    }

                }
                else if(moveDir == "D")
                {
                    head.Y--;
                    if (tail.X == head.X) //samma bredd
                    {
                        if (tail.Y-1 > head.Y) //T över H
                            tail.Y--;
                        else if (tail.Y == head.Y || tail.Y - 1 == head.Y)
                        {//do Noting with tail
                        }

                    }
                    else if(tail.Y == head.Y+2 && tail.X == head.X-1)//T snett över vänster om H
                    {
                        tail.Y--;
                        tail.X++;
                    }
                    else if (tail.Y == head.Y+2 && tail.X == head.X+1)//T snett över höger om H
                    {
                        tail.Y--;
                        tail.X--;
                    }

                }
                else if (moveDir == "L")
                {
                    head.X--;
                    if (tail.Y == head.Y) //samma höjd
                    {
                        if (tail.X-1 > head.X) //T höger om H
                            tail.X--;
                        else if(tail.X == head.X || tail.X - 1 == head.X) 
                        {//do Noting with tail
                        }
                            
                    }
                    else if(tail.Y == head.Y+1 && tail.X == head.X+2)//T snett över höger om H
                    {
                        tail.Y--;
                        tail.X--;
                    }
                    else if(tail.Y == head.Y-1 && tail.X == head.X+2)//T snett under höger om H
                    {
                        tail.Y++;
                        tail.X--;
                    }


                }
                else if (moveDir == "R")
                {
                    head.X++;
                    if(tail.Y == head.Y) //samma höjd
                    {
                        if (tail.X+1 < head.X) //T vänster om H
                            tail.X++;
                        else if (tail.X == head.X || tail.X + 1 == head.X)
                        {//do Noting with tail
                        }
                    }

                    else if(tail.X == head.X -2 && tail.Y == head.Y - 1)//T snett under vänster om
                    {
                        tail.X++;
                        tail.Y++;
                    }


                    else if(tail.X == head.X - 2 && tail.Y == head.Y + 1)//T snett över vänster om
                    {
                        tail.X++;
                        tail.Y--;
                    }
                    //else if(tail.X == head.X + 1 && tail.Y == head.Y)//T över H
                    //{
                    //    //do noting with tail
                    //}
                    //else if(tail.X == head.X -1 && tail.Y == head.Y)//T Under H
                    //{
                    //    //do noting with tail
                    //}

                }
                //Console.WriteLine("Pos: " + tail.Y + "," + tail.X);
                placesVisited.Add((tail.X, tail.Y));
            }
        }

        return "A: " + placesVisited.Distinct().Count();
    }
    public static string B()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec9\Input92.txt").ToList();
        //skapa lista av snören(tail head) med storlek 9.: H1, 12, 23, 34,45,56,67,78,89
        //sen kör ovan på varje rep 
        Rope rope = new Rope(10);
        var placesVisitedForTail = new List<(int x, int y)>();

        placesVisitedForTail.Add((0, 0));
        foreach (var c in input)
        {
            rope.MoveRope(int.Parse(c.Split(' ')[1]), c.Split(' ')[0]);
            //rope.Print();
            placesVisitedForTail.Add((rope.Tail.X, rope.Tail.Y));
        }
        
        Console.WriteLine();
        return "B: " + rope.PlacesVisitedForTail.Distinct().Count();
    }

}
public class Rope
{
    public List<RopeKnot2> Knots= new List<RopeKnot2>();
    public RopeKnot2 Tail { get; set; }
    public List<(int x, int y)>  PlacesVisitedForTail { get; set; }

    public Rope (int size)
    {
        List<RopeKnot2> tempKnots = new List<RopeKnot2>();
        for (int i = 0; i< size; i++)
        {
            tempKnots.Add(new(0, 0, i.ToString()));
        }
        Knots = tempKnots;
        Tail = Knots.Last();
        PlacesVisitedForTail = new List<(int x, int y)>();
        PlacesVisitedForTail.Add((0, 0));
    }

    public void MoveRope(int num, string dir)
    {
        for (int j = 0; j < num; j++)
        {
            for (int i = 0; i < Knots.Count() - 1; i++)
            {
                
                if (i == 0)
                {
                    if (dir == "U")
                        Knots[i].Y++;
                    else if (dir == "D")
                        Knots[i].Y--;
                    else if (dir == "L")
                        Knots[i].X--;
                    else
                        Knots[i].X++;
                }

                //LEFT
                if (Knots[i + 1].Y == Knots[i].Y && Knots[i + 1].X == Knots[i].X + 2) //T höger om H
                { 
                        Knots[i + 1].X--;

                }
                else if (Knots[i + 1].Y == Knots[i].Y + 1 && Knots[i + 1].X == Knots[i].X + 2)//T snett över höger om H
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 1 && Knots[i + 1].X == Knots[i].X + 2)//T snett under höger om H
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X--;
                }
                //--------------

                //RIGHT
                else if (Knots[i + 1].Y == Knots[i].Y && Knots[i + 1].X == Knots[i].X - 2) //T vänster om H
                {
                        Knots[i + 1].X++;
                }

                else if (Knots[i + 1].X == Knots[i].X - 2 && Knots[i + 1].Y == Knots[i].Y - 1)//T snett under vänster om
                {
                    Knots[i + 1].X++;
                    Knots[i + 1].Y++;
                }


                else if (Knots[i + 1].X == Knots[i].X - 2 && Knots[i + 1].Y == Knots[i].Y + 1)//T snett över vänster om
                {
                    Knots[i + 1].X++;
                    Knots[i + 1].Y--;
                }
                //--------------
                //UP
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X) //T under H
                {
                    Knots[i + 1].Y++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X - 1)//T snett vänster under H
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X + 1)////T snett höger under H
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X--;
                }
                //--------------
                //DOWN
                else if (Knots[i + 1].X == Knots[i].X) //samma bredd
                {
                    if (Knots[i + 1].Y - 1 > Knots[i].Y) //T över H
                        Knots[i + 1].Y--;

                }
                else if (Knots[i + 1].Y == Knots[i].Y + 2 && Knots[i + 1].X == Knots[i].X - 1)//T snett över vänster om H
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y + 2 && Knots[i + 1].X == Knots[i].X + 1)//T snett över höger om H
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X--;
                }
                //--------------
                //SPECIAL
                else if (Knots[i + 1].Y == Knots[i].Y - 1 && Knots[i + 1].X == Knots[i].X - 2) //1
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X - 2)//2
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X++;
                }

                else if (Knots[i + 1].Y == Knots[i].Y - 1 && Knots[i + 1].X == Knots[i].X + 2)//3
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X + 1)//4
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2 && Knots[i + 1].X == Knots[i].X - 1)//5
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y - 2&& Knots[i + 1].X == Knots[i].X - 1)//6
                {
                    Knots[i + 1].Y++;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y + 1 && Knots[i + 1].X == Knots[i].X +2 )//7
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y +2 && Knots[i + 1].X == Knots[i].X +2 )//8
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y +2 && Knots[i + 1].X == Knots[i].X +1 )//9
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X--;
                }
                else if (Knots[i + 1].Y == Knots[i].Y +2 && Knots[i + 1].X == Knots[i].X - 1)//10
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y + 2 && Knots[i + 1].X == Knots[i].X - 2)//11
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X++;
                }
                else if (Knots[i + 1].Y == Knots[i].Y +1 && Knots[i + 1].X == Knots[i].X - 2)//12
                {
                    Knots[i + 1].Y--;
                    Knots[i + 1].X++;
                }
                //--------------
                PlacesVisitedForTail.Add((Tail.X, Tail.Y));
            }

        }

    }

    public void Print()
    {
        // start x = 11 y = 5 // 0 = 0
        var grid = new string[50,50];
        
        var rKnots = new List<RopeKnot2>();
        foreach(var k in Knots)
        {
            rKnots.Add(k);
        }
        rKnots.Reverse();
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                grid[j, i] = ".";
            }
        }
        foreach (var k in rKnots)
        {
            grid[k.X+20, k.Y+20] = k.Name;
        }


        for (int i = 49; i >= 0; i--)
        {
            Console.WriteLine();
            for (int j = 0; j < 50; j++)
            {
                Console.Write(grid[j, i]);
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------");

    }

    

}
public class RopeKnot
{
    public int X { get; set; }
    public int Y { get; set; }

    public RopeKnot(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class RopeKnot2
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; }

    public RopeKnot2(int x, int y, string name)
    {
        X = x;
        Y = y;
        Name = name;
    }
}



