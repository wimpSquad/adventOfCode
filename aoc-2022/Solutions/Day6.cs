public static class DaySix
{
    public static void Solve()
    {
        var fileName = "PuzzleInput\\Day6.txt";
        var text = File.ReadAllText(fileName);

        Console.WriteLine($"Start of packet character for part one: {SolvePartOne(text)}");
        
        Console.WriteLine($"Start of packet character for part two: {SolvePartTwo(text)}");
    }

    public static int SolvePartOne(string input)
    {
        var markerLength = 4;

        return FindMarker(input, markerLength);
    }

    public static int SolvePartTwo(string input)
    {
        var markerLength = 14;

        return FindMarker(input, markerLength);
    }

    private static int FindMarker(string input, int markerLength)
    {
        var marker = "";
        
        for (var i = 0; i < input.Length; i++)
        {
            if (marker.Length < markerLength)
            {
                marker += input[i];
            }
            else
            {
                var containsDistinctChars = ContainsDistinctChars(marker, markerLength);

                if (!containsDistinctChars)
                {
                    marker = marker.Remove(0, 1);
                    marker += input[i];
                }
                else
                {
                    return i;
                }
            }
        }

        return 0;
    }

    private static bool ContainsDistinctChars(string marker, int markerLength)
    {
        var distinctChars = marker.Distinct();
        
        return distinctChars.Count() == markerLength;
    }
}