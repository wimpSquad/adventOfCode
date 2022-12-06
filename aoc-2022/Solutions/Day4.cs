public static class DayFour
{
    public static void Solve()
    {
        var fileName = "PuzzleInput\\Day4.txt";
        var lines = File.ReadLines(fileName);

        Console.WriteLine($"Number of pairs where one envelops the other: {SolvePartOne(lines)}");

        Console.WriteLine($"Number of pairs where one overlaps the other: {SolvePartTwo(lines)}");
    }

    private static int SolvePartOne(IEnumerable<string> lines)
    {
        var fullyEnclosedCount = 0;
        var rangePairs = GetRangePairs(lines);

        foreach (var rangePair in rangePairs)
        {
            if (rangePair[0] <= rangePair[2] && rangePair[1] >= rangePair[3])
            {
                fullyEnclosedCount++;
            }
            else if (rangePair[2] <= rangePair[0] && rangePair[3] >= rangePair[1])
            {
                fullyEnclosedCount++;
            }
        }

        return fullyEnclosedCount;
    }

    private static int SolvePartTwo(IEnumerable<string> lines)
    {
        var anyOverlapCount = 0;
        var rangePairs = GetRangePairs(lines);

        foreach (var rangePair in rangePairs)
        {
            var hasOverlap = false;
            var firstRangeValues = new List<int>();
            var secondRangeValues = new List<int>();

            for (int i = rangePair[0]; i <= rangePair[1]; i++)
            {
                firstRangeValues.Add(i);
            }

            for (int i = rangePair[2]; i <= rangePair[3]; i++)
            {
                secondRangeValues.Add(i);
            }

            foreach (var value in firstRangeValues)
            {
                if (secondRangeValues.Contains(value))
                {
                    hasOverlap = true;
                }
            }

            if (hasOverlap) anyOverlapCount++;
            hasOverlap = false;
        }

        return anyOverlapCount;
    }

    private static List<List<int>> GetRangePairs(IEnumerable<string> lines)
    {
        var rangePairs = new List<List<int>>();

        foreach (var line in lines)
        {
            var newLine = line.Replace(',', '-');
            
            var intList = new List<int>();

            foreach (var item in newLine.Split('-'))
            {
                intList.Add(int.Parse(item));
            }

            rangePairs.Add(intList);
        }

        return rangePairs;
    }
}