public static class DayTwo
{
    // Column 1
        // A - Rock
        // B - Paper
        // C - Scissors
    // Column 2
        // Y - Paper // Draw
        // X - Rock // Lose
        // Z - Scissors // Win
    public static void Solve()
    {
        var fileName = "PuzzleInput\\Day2.txt";
        var lines = File.ReadLines(fileName);

        var scoresPartOne = new List<int>();
        var scoresPartTwo = new List<int>();

        foreach (var line in lines)
        {
            var thisScorePartOne = GetScorePartOne(line[0], line[2]);
            
            scoresPartOne.Add(thisScorePartOne);
            
            var thisScorePartTwo = GetScorePartTwo(line[0], line[2]);

            scoresPartTwo.Add(thisScorePartTwo);
        }

        Console.WriteLine($"Total points based on what we thought was the strategy guide: {scoresPartOne.Sum()}");
        Console.WriteLine($"Total points based on the actual strategy guide: {scoresPartTwo.Sum()}");
    }

    private static int GetScorePartOne(char playerOne, char playerTwo)
    {
        var points = 0;

        switch(playerTwo)
        {
            case 'X':
                points += 1;
                break;
            case 'Y':
                points += 2;
                break;
            case 'Z':
                points += 3;
                break;
        }

        switch (playerOne)
        {
            case 'A':
                switch (playerTwo)
                {
                    case 'Y':
                        points += 6;
                        break;
                    case 'X':
                        points += 3;
                        break;
                }
                break;
            case 'B':
                switch (playerTwo)
                {
                    case 'Z':
                        points += 6;
                        break;
                    case 'Y':
                        points += 3;
                        break;
                }
                break;
            case 'C':
                switch (playerTwo)
                {
                    case 'X':
                        points += 6;
                        break;
                    case 'Z':
                        points += 3;
                        break;
                }
                break;
        }

        return points;
    }

    private static int GetScorePartTwo(char playerOne, char strategy)
    {
        var score = 0;

        switch (strategy)
        {
            case 'X': // lose
                switch (playerOne)
                {
                    case 'A':
                        score += 3;
                        break;
                    case 'B':
                        score += 1;
                        break;
                    case 'C':
                        score += 2;
                        break;
                }
                break;
            case 'Y': // draw
                score += 3;
                switch (playerOne)
                {
                    case 'A':
                        score += 1;
                        break;
                    case 'B':
                        score += 2;
                        break;
                    case 'C':
                        score += 3;
                        break;
                }
                break;
            case 'Z': // win
                score += 6;
                switch (playerOne)
                {
                    case 'A':
                        score += 2;
                        break;
                    case 'B':
                        score += 3;
                        break;
                    case 'C':
                        score += 1;
                        break;
                }
                break;
        }

        return score;
    }

}