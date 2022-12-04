public class DayThree
{
    private static Dictionary<char, int> CharPriorities()
    {
        var dictionary = new Dictionary<char, int>();

        dictionary.Add('a', 1);
        dictionary.Add('b', 2);
        dictionary.Add('c', 3);
        dictionary.Add('d', 4);
        dictionary.Add('e', 5);
        dictionary.Add('f', 6);
        dictionary.Add('g', 7);
        dictionary.Add('h', 8);
        dictionary.Add('i', 9);
        dictionary.Add('j', 10);
        dictionary.Add('k', 11);
        dictionary.Add('l', 12);
        dictionary.Add('m', 13);
        dictionary.Add('n', 14);
        dictionary.Add('o', 15);
        dictionary.Add('p', 16);
        dictionary.Add('q', 17);
        dictionary.Add('r', 18);
        dictionary.Add('s', 19);
        dictionary.Add('t', 20);
        dictionary.Add('u', 21);
        dictionary.Add('v', 22);
        dictionary.Add('w', 23);
        dictionary.Add('x', 24);
        dictionary.Add('y', 25);
        dictionary.Add('z', 26);

        dictionary.Add('A', 27);
        dictionary.Add('B', 28);
        dictionary.Add('C', 29);
        dictionary.Add('D', 30);
        dictionary.Add('E', 31);
        dictionary.Add('F', 32);
        dictionary.Add('G', 33);
        dictionary.Add('H', 34);
        dictionary.Add('I', 35);
        dictionary.Add('J', 36);
        dictionary.Add('K', 37);
        dictionary.Add('L', 38);
        dictionary.Add('M', 39);
        dictionary.Add('N', 40);
        dictionary.Add('O', 41);
        dictionary.Add('P', 42);
        dictionary.Add('Q', 43);
        dictionary.Add('R', 44);
        dictionary.Add('S', 45);
        dictionary.Add('T', 46);
        dictionary.Add('U', 47);
        dictionary.Add('V', 48);
        dictionary.Add('W', 49);
        dictionary.Add('X', 50);
        dictionary.Add('Y', 51);
        dictionary.Add('Z', 52);

        return dictionary;
    }
    public static void Solve()
    {
        var fileName = "PuzzleInput\\Day3.txt";
        var lines = File.ReadLines(fileName);

        var commonChars = new List<char>();

        foreach (var line in lines)
        {
            var charCount = line.Length;
            var halfCount = charCount / 2;

            var firstHalf = line.Remove(halfCount);
            var secondHalf = line.Remove(0, halfCount);

            var thisCommonChars = new List<char>();

            foreach (var thisChar in firstHalf)
            {
                if (secondHalf.Contains(thisChar))
                {
                    thisCommonChars.Add(thisChar);                    
                }
            }

            commonChars.Add(thisCommonChars[0]);
        }

        var commonCharsValues = new List<int>();

        foreach (var thisChar in commonChars)
        {
            var charValue = GetCharValues(thisChar);

            commonCharsValues.Add(charValue);
        }

        Console.WriteLine($"The sum of the priorities for part one: {commonCharsValues.Sum()}");

        SolvePartTwo(lines);
    }

    private static void SolvePartTwo(IEnumerable<string> lines)
    {
        var securityGroups = new List<List<string>>();
        var securityGroup = new List<string>();

        foreach (var line in lines)
        {
            if (securityGroup.Count < 3)
            {
                securityGroup.Add(line);
            }
            else
            {
                var thisSecurityGroup = new List<string>();
                
                thisSecurityGroup.AddRange(securityGroup);
                
                securityGroups.Add(thisSecurityGroup);
                securityGroup.Clear();
                securityGroup.Add(line);
            }
        }

        securityGroups.Add(securityGroup);

        var securityGroupPriorities = new List<int>();

        foreach (var group in securityGroups)
        {
            var priority = FindAuthenticityStickerPriority(group);

            securityGroupPriorities.Add(priority);
        }

        Console.WriteLine($"Sum of badge priorities for part two: {securityGroupPriorities.Sum()}");
    }

    private static int FindAuthenticityStickerPriority(List<string> securityGroup)
    {
        foreach(var thisChar in securityGroup[0])
        {
            if (securityGroup[1].Contains(thisChar))
            {
                if (securityGroup[2].Contains(thisChar))
                {
                    return GetCharValues(thisChar);
                }
            }
        }

        return 0;
    }

    private static int GetCharValues(char thisChar)
    {
        var charValue = CharPriorities().Single(x => x.Key == thisChar).Value;

        return charValue;
    }
}