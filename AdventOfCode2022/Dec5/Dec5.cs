using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec5
{
    public static string TopCrates()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec5\Input5.txt").ToList();

        var craneMoves = input.Where(x => x.Contains("move"));
        var listsInput = input.Where(x => !x.Contains("move") && x != "");


        List<List<char>> listOfLists = new List<List<char>>();
        for (int i = listsInput.Count() - 1; i >= 0; i--)
        {

            for (int j = 0; j < (listsInput.Last().Count() + 1) / 4; j++)
            {
                if (i == listsInput.Count() - 1)
                {
                    listOfLists.Add(new List<char>());
                }
                else
                {
                    if (listsInput.ElementAt(i)[1 + (j * 4)] != ' ')
                    {
                        listOfLists.ElementAt(j).Add(listsInput.ElementAt(i)[1 + (j * 4)]);
                    }
                }
            }
        }

        foreach (var move in craneMoves)
        {
            string moveArray = new String(move.Where(Char.IsDigit).ToArray());
            if (moveArray.Length == 4)
            {
                listOfLists = Crane9000(listOfLists, (moveArray[0].ToString() + moveArray[1].ToString()), moveArray[2].ToString(), moveArray[3].ToString());
            }
            else
            {
                listOfLists = Crane9000(listOfLists, moveArray[0].ToString(), moveArray[1].ToString(), moveArray[2].ToString());
            }


        }

        string resultString = "";
        foreach (var l in listOfLists)
        {
            resultString += l.Last().ToString();
        }

        Console.WriteLine(" ");
        return "Sammansatta sträng för dem sista karaktärerna i högarna för 9000 är: " + resultString;
    }

    public static List<List<char>> Crane9000(List<List<char>> listOfList, string moveCount, string fromListNumber, string toListNumber)
    {
        List<List<char>> tempListOfLists = listOfList;
        var fromList = listOfList.ElementAt(int.Parse(fromListNumber) - 1);
        var toList = listOfList.ElementAt(int.Parse(toListNumber) - 1);

        var movePart = fromList.GetRange(fromList.Count() - int.Parse(moveCount), int.Parse(moveCount));
        fromList.RemoveRange(fromList.Count() - int.Parse(moveCount), int.Parse(moveCount));
        movePart.Reverse();
        foreach (var e in movePart)
        {
            toList.Add(e);
        }

        return tempListOfLists;
    }
    public static List<List<char>> Crane9001(List<List<char>> listOfList, string moveCount, string fromListNumber, string toListNumber)
    {
        List<List<char>> tempListOfLists = listOfList;
        var fromList = listOfList.ElementAt(int.Parse(fromListNumber) - 1);
        var toList = listOfList.ElementAt(int.Parse(toListNumber) - 1);

        var movePart = fromList.GetRange(fromList.Count() - int.Parse(moveCount), int.Parse(moveCount));
        fromList.RemoveRange(fromList.Count() - int.Parse(moveCount), int.Parse(moveCount));
        //movePart.Reverse();
        foreach (var e in movePart)
        {
            toList.Add(e);
        }

        return tempListOfLists;
    }

    public static string TopCrates2()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec5\Input5.txt").ToList();

        var craneMoves = input.Where(x => x.Contains("move"));
        var listsInput = input.Where(x => !x.Contains("move") && x != "");


        List<List<char>> listOfLists = new List<List<char>>();
        for (int i = listsInput.Count() - 1; i >= 0; i--)
        {

            for (int j = 0; j < (listsInput.Last().Count() + 1) / 4; j++)
            {
                if (i == listsInput.Count() - 1)
                {
                    listOfLists.Add(new List<char>());
                }
                else
                {
                    if (listsInput.ElementAt(i)[1 + (j * 4)] != ' ')
                    {
                        listOfLists.ElementAt(j).Add(listsInput.ElementAt(i)[1 + (j * 4)]);
                    }
                }
            }
        }

        foreach (var move in craneMoves)
        {
            string moveArray = new String(move.Where(Char.IsDigit).ToArray());
            if (moveArray.Length == 4)
            {
                listOfLists = Crane9001(listOfLists, (moveArray[0].ToString() + moveArray[1].ToString()), moveArray[2].ToString(), moveArray[3].ToString());
            }
            else
            {
                listOfLists = Crane9001(listOfLists, moveArray[0].ToString(), moveArray[1].ToString(), moveArray[2].ToString());
            }


        }
        string resultString = "";
        foreach (var l in listOfLists)
        {
            resultString += l.Last().ToString();
        }

        Console.WriteLine(" ");
        return "Sammansatta sträng för dem sista karaktärerna i högarna för 9001 är: " + resultString;
    }
}

