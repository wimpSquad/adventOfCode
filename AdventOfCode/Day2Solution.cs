using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Classes;

namespace AdventOfCode
{
    public class Day2Solution
    {
        private Keypad _keypad = new Keypad();

        public Day2Solution()
        {
            Console.WriteLine("Starting...");
            Day2_ParseInput();
            Console.WriteLine($"Current combination is {Keypad.Combination}");
        }

        private void Day2_ParseInput()
        {
            var fileLines = File.ReadAllLines(@"Resource\\Day2_Input.txt");

            foreach (var line in fileLines)
            {
                _keypad.FindKey(line);
                Console.WriteLine($"Found combination entry: {Keypad.Combination.Last()}");
            }
            Console.WriteLine($"Final combination is {Keypad.Combination[0]}{Keypad.Combination[1]}{Keypad.Combination[2]}{Keypad.Combination[3]}{Keypad.Combination[4]}");
            Console.ReadLine();
        }
    }
}
