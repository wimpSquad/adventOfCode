public static class DayOne
{
    public static void DoStuff()
    {
        Console.WriteLine(SolveThisHerePuzzle());
    }
    private static List<int> GetPuzzleInput()
    {
        var fileName = "PuzzleInput\\Day1.txt";
        var lines = File.ReadLines(fileName);

        var puzzleInput = new List<int>();

        foreach (var line in lines)
        {
            puzzleInput.Add(int.Parse(line));
        }

        return puzzleInput;
    }

    private static int SolveThisHerePuzzle()
    {
        var puzzleInput = GetPuzzleInput();
        var currentVal = 0;
        var incrementor = 0;

        foreach(var value in puzzleInput) {
            if (value == puzzleInput[0]) {
                currentVal = value;
                continue;
            }

            if(value > currentVal) incrementor++;

            currentVal = value;
        }

        return incrementor;
    }
}