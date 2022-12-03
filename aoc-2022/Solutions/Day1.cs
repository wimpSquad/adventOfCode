public static class DayOne 
{
    public static void Solve() 
    {
        // Define where we put the puzzle input (created a .txt file and copied/pasted)
        var fileName = "PuzzleInput\\Day1.txt";
        
        // Read all of the lines of the .txt file into memory
        var lines = File.ReadLines(fileName);

        // Define some variables we'll use later
        var elfStash = new List<List<int>>();
        var foodItems = new List<int>();
        
        // Loop through each line of the input file and perform some logic
        foreach (var line in lines)
        {
            // Check and see if this line can be converted to an int.  If it can, it's a foodItem.  If not, next Elf.
            if (int.TryParse(line, out int foodItem))
            {
                foodItems.Add(foodItem);
            }
            else
            {
                
                // We can't just add foodItems directly to elfStash because it's a defined spot in memory.  Create a new object with the same values.
                var allFoodThisElf = new List<int>();
                allFoodThisElf.AddRange(foodItems);

                // Clear out the list for this Elf so we can use it next time, and add this Elve's food items to the elfStash.
                foodItems.Clear();
                elfStash.Add(allFoodThisElf);
            }
        }

        FindElfWithMostCalories(elfStash);
        FindTopThreeCalorieElves(elfStash);
    }

    private static void FindElfWithMostCalories(List<List<int>> elfStash) 
    {
        // Start with zero.  Go through each Elf's stash, get the sum.  If it's higher than the one before, replace the value.
        var maxCalories = 0;
        foreach (var stash in elfStash)
        {
            if (stash.Sum() > maxCalories)
            {
                maxCalories = stash.Sum();
            }
        }

        // Here we have the solution to Part 1!        
        Console.WriteLine($"Most calories held by a single Elf: {maxCalories}");
    }

    private static void FindTopThreeCalorieElves(List<List<int>> elfStash)
    {
        // Here, we only care about the sum of the top three elves.  We can simplify our elfStash object and use a sorting function to make it easy.

        var elfCalories = new List<int>();

        foreach (var stash in elfStash)
        {
            elfCalories.Add(stash.Sum());
        }

        // Now we have total calories per Elf in our list.  We sort the list and grab the top three.
        elfCalories.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine($"Total calories of the top three Elves: {elfCalories.Take(3).Sum()}");
    }
}