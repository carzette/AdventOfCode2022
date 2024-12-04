
public static class Dec2
{
    public static string A()
    {
        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec2\Input2.txt").ToList();

        int safeReports = 0;

        foreach (var e in input)
        {
            var numbers = e.Split(' ').Select(int.Parse).ToArray().ToList();

            List<int> differences = numbers.Zip(numbers.Skip(1), (a, b) => b - a).ToList();
            if (SafeReport(differences))
                safeReports++;
        }
        return "Number of reports that are safe is: " + safeReports;
    }

    public static string B()
    {
        var input = File.ReadAllLines(@"C:\Users\Carl\source\repos\carzette\AdventOfCode2022\AOC2024\Dec2\Input2.txt").ToList();

        int safeReports = 0;

        foreach (var e in input)
        {
            var numbers = e.Split(' ').Select(int.Parse).ToArray().ToList();

            List<int> differences = numbers.Zip(numbers.Skip(1), (a, b) => b - a).ToList();
            if (SafeReport(differences))
                safeReports++;
            else
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    var numbersWithout = numbers.Take(i).Concat(numbers.Skip(i + 1)).ToList();
                    var differencess = numbersWithout.Zip(numbersWithout.Skip(1), (a, b) => b - a).ToList();
                    if (SafeReport(differencess))
                    {
                        safeReports++;
                        break;
                    }


                }
            }

        }

        return "Number of reports that are safe is: " + safeReports;
    }

    private static bool SafeReport(List<int> l)
    {
        return l.All(x => x >= 1 && x <= 3) || l.All(x => x >= -3 && x <= -1);
    }
}

