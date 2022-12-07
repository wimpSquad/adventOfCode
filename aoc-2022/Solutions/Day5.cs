public static class DayFive
{
    private static Dictionary<int, string> _crateStacks;
    private static List<MoveDirections> _moveDirections;
    public static void Solve()
    {
        _moveDirections = BuildMoveDirections();

        Console.WriteLine($"The top crate from each stack for part one: {SolvePartOne()}");
        Console.WriteLine($"The top crate from each stack for part two: {SolvePartTwo()}");
    }

    private static string SolvePartOne()
    {
        _crateStacks = BuildInitialCrateStack();

        foreach (var moveDirection in _moveDirections)
        {
            for (int i = 0; i < moveDirection.Qty; i++)
            {
                var originCrateStack = _crateStacks[moveDirection.Origin];
                var destinationCrateStack = _crateStacks[moveDirection.Destination];

                destinationCrateStack = originCrateStack.First() + destinationCrateStack;
                originCrateStack = originCrateStack.Remove(0, 1);

                _crateStacks[moveDirection.Origin] = originCrateStack;
                _crateStacks[moveDirection.Destination] = destinationCrateStack;
            }
        }

        return GetTopCrates();
    }

    private static string SolvePartTwo()
    {
        _crateStacks = BuildInitialCrateStack();

        foreach (var moveDirection in _moveDirections)
        {
            var originCrateStack = _crateStacks[moveDirection.Origin];
            var destinationCrateStack = _crateStacks[moveDirection.Destination];

            destinationCrateStack = originCrateStack.Substring(0, moveDirection.Qty) + destinationCrateStack;
            originCrateStack = originCrateStack.Remove(0, moveDirection.Qty);

            _crateStacks[moveDirection.Origin] = originCrateStack;
            _crateStacks[moveDirection.Destination] = destinationCrateStack;
        }

        return GetTopCrates();
    }

    private static string GetTopCrates()
    {
        var topCrates = "";

        foreach (var crateStack in _crateStacks)
        {
            topCrates += crateStack.Value.First();
        }

        return topCrates;
    }

    private static Dictionary<int, string> BuildInitialCrateStack()
    {
        // crates are ordered left:right :: top:bottom
        var crateStacks = new Dictionary<int, string> 
        {
            { 1, "BVWTQNHD" },
            { 2, "BWD" },
            { 3, "CJWQST" },
            { 4, "PTZNRJF" },
            { 5, "TSMJVPG" },
            { 6, "NTFWB" },
            { 7, "NVHFQDLB" },
            { 8, "RFPH" },
            { 9, "HPNLBMSZ" }
        };

        return crateStacks;
    }

    private static List<MoveDirections> BuildMoveDirections()
    {
        var fileName = "PuzzleInput\\Day5.txt";
        var lines = File.ReadLines(fileName);

        var moveDirections = new List<MoveDirections>();

        foreach (var line in lines)
        {
            var newLine = line.Replace("move ", "");
            newLine = newLine.Replace(" from ", "-");
            newLine = newLine.Replace(" to ", "-");

            var newLineSplit = newLine.Split("-");
            var moveDirection = new MoveDirections 
            {
                Qty = int.Parse(newLineSplit[0]),
                Origin = int.Parse(newLineSplit[1]),
                Destination = int.Parse(newLineSplit[2])
            };

            moveDirections.Add(moveDirection);
        }

        return moveDirections;
    }
}

public class MoveDirections
{
    public int Qty { get; set; }
    public int Origin { get; set; }
    public int Destination { get; set; }
}