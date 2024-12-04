
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public static class Dec4
{
    public static string A()
    {
        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec4\Input4.txt").ToList();
        var totalXmas = 0;

        for (int y = 0; y< input.Count; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
              

                if(x <= input[0].Length - 4 && input[y][x] == 'X' && input[y][x+1] == 'M' && input[y][x+2] == 'A' && input[y][x + 3] == 'S') //höger
                    totalXmas++;
                if(x >= 3 && input[y][x] == 'X' && input[y][x - 1] == 'M' && input[y][x - 2] == 'A' && input[y][x - 3] == 'S')//vänster
                    totalXmas++;
                if (y <= input.Count - 4 && input[y][x] == 'X' && input[y+1][x] == 'M' && input[y + 2][x] == 'A' && input[y+3][x] == 'S')//ner
                    totalXmas++;
                if (y >= 3 && input[y][x] == 'X' && input[y - 1][x] == 'M' && input[y - 2][x] == 'A' && input[y - 3][x] == 'S')//upp
                    totalXmas++;

                //sen upp höger
                if (y >= 3 && x <= input[0].Length - 4 &&
                    input[y][x] == 'X' && input[y-1][x+1] == 'M' && input[y - 2][x+2] == 'A' && input[y - 3][x+3] == 'S')
                    totalXmas++;
                //sne uppp vänster
                if (y >= 3 && x >= 3 &&
                    input[y][x] == 'X' && input[y - 1][x - 1] == 'M' && input[y - 2][x - 2] == 'A' && input[y - 3][x - 3] == 'S')
                    totalXmas++;
                //sne ner höger
                if (y <= input.Count - 4 && x <= input[0].Length - 4 &&
                    input[y][x] == 'X' && input[y + 1][x + 1] == 'M' && input[y + 2][x + 2] == 'A' && input[y + 3][x + 3] == 'S')
                    totalXmas++;
                //sne ner vänster
                if (y <= input.Count - 4 && x >= 3 &&
                    input[y][x] == 'X' && input[y + 1][x - 1] == 'M' && input[y + 2][x - 2] == 'A' && input[y + 3][x - 3] == 'S')
                    totalXmas++;

            }
            
        }



        return "total occurence of word Xmas: " + totalXmas;
    }

    public static string B()
    {

        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec4\Input4.txt").ToList();
        var totalX_mas = 0;

        for (int y = 0; y < input.Count-2; y++)
        {
            for (int x = 0; x < input[0].Length-2; x++)
            {
                //Console.Write(input[y][x]);
                
                if (input[y][x] == 'M' && input[y][x + 2] == 'S' && input[y+1][x + 1] == 'A' && input[y+2][x] == 'M' && input[y + 2][x+2] == 'S') //m.m vänster
                    totalX_mas++;

                if (input[y][x] == 'M' && input[y][x + 2] == 'M' && input[y + 1][x + 1] == 'A' && input[y + 2][x] == 'S' && input[y + 2][x + 2] == 'S')//m.m toppen
                    totalX_mas++;

                if (input[y][x] == 'S' && input[y][x + 2] == 'M' && input[y + 1][x + 1] == 'A' && input[y + 2][x] == 'S' && input[y + 2][x + 2] == 'M')//m.m höger
                    totalX_mas++;

                if (input[y][x] == 'S' && input[y][x + 2] == 'S' && input[y + 1][x + 1] == 'A' && input[y + 2][x] == 'M' && input[y + 2][x + 2] == 'M')//m.m botten
                    totalX_mas++;


            }
            //Console.WriteLine();
        }



        return "total occurence of word X-mas: " + totalX_mas;
                                                              
    }


}


