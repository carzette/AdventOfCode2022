using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Text;
using System.Diagnostics;
public static class Dec11
{
    public static string AB(string part)
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec11\Input11.txt").ToList().ToList();
        var rounds = part == "1" ? 20 : 10000;
        List<List<string>> monkeyInfo = new List<List<string>>();
        var monkeyIndex = 0;
        for (int i = 1; i <= input.Count(); i++)
        {
            if ((i + 6) % 7 == 0)
                monkeyInfo.Add(new List<string>());
            if (i % 7 == 0)
                monkeyIndex++;
            else
            {
                monkeyInfo[monkeyIndex].Add(input[i - 1]);
            }
        }
        var monkeys = new List<(string name, List<Item> items, long div)>();
        var listOfInspections = new List<int>();
        foreach (var info in monkeyInfo)
        {
            var name = info[0].Split(' ')[1].Remove(info[0].Split(' ')[1].Length - 1);
            var items = info[1].Split(':')[1].Split(',').Select(int.Parse).ToList().Select(x => new Item(long.Parse(x.ToString()))).ToList();
            var div = int.Parse(info[3].Split(' ').Last());
            monkeys.Add((name, items, div));
            listOfInspections.Add(0);

        }
        for (int y = 0; y < rounds; y++) 
        {


            monkeyIndex = 0;

            foreach (var monkey in monkeys)
            {
                
                var itemsNumber = monkey.items.Count();
                for (int j = 0; j < itemsNumber; j++)
                {

                    if (monkeyInfo[monkeyIndex][2].Contains("*"))
                    {
                        if (monkeyInfo[monkeyIndex][2].Split(' ').Last() != "old")
                            monkey.items[0].value *= long.Parse(monkeyInfo[monkeyIndex][2].Split(' ').Last());
                        else
                            monkey.items[0].value *= monkey.items[0].value;
                    }
                    else
                    {
                        monkey.items[0].value += long.Parse(monkeyInfo[monkeyIndex][2].Split(' ').Last());
                    }
                    monkey.items[0].value = part == "1" ? monkey.items[0].value / 3 : monkey.items[0].value % (long)LCM(monkeys.Select(x => x.div).ToArray());

                    if (monkey.items[0].value % int.Parse(monkeyInfo[monkeyIndex][3].Split(' ').Last()) == 0)
                    {
                        monkeys[int.Parse(monkeyInfo[monkeyIndex][4].Split(' ').Last())].items.Add(monkey.items[0]);
                    }
                    else
                    {
                        monkeys[int.Parse(monkeyInfo[monkeyIndex][5].Split(' ').Last())].items.Add(monkey.items[0]);
                    }
                    monkeys[monkeyIndex].items.RemoveAt(0);
                    listOfInspections[monkeyIndex]++;
                }
                monkeyIndex++;
            }


        }
        return "Monkey business of " + part + ": " + ((long)listOfInspections.Max() * (long)listOfInspections.Where(x => x < (long)listOfInspections.Max()).Max());
    }
    public static long LCM(long[] ofNumbers)
    {
        long ans = ofNumbers[0];
        for (int i = 1; i < ofNumbers.Length; i++)
        {
            ans = ofNumbers[i] * ans / GCD(ofNumbers[i], ans);
        }
        return ans;
    }
    private static long GCD(long a, long b) { return b == 0 ? a : GCD(b, a % b); }


}
public class Item
{
    public long value { get; set; }

    public Item(long value)
    {
        this.value = value;
    }
}
