using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Classes;

namespace AdventOfCode
{
    public class Day1Solution
    {
        public Compass AdventCompass = new Compass();
        public Day1Solution()
        {
            var input = Week1_ParseInput();
            Console.WriteLine("Starting at square 1... : " + Compass.CurrentPlacement.Item1[0] + "N, " + Compass.CurrentPlacement.Item1[1] + "E, " + "currently facing " + Compass.CurrentPlacement.Item2);
            foreach (var val in input)
            {
                Console.WriteLine("Input from file: " + val);
                AdventCompass.Turn(val);
                Console.WriteLine(Compass.CurrentPlacement.Item1[0] + "N, " + Compass.CurrentPlacement.Item1[1] + "E, " + "currently facing " + Compass.CurrentPlacement.Item2);
            }

            Console.WriteLine("Distance to Easter Bunny HQ: " + (Compass.CurrentPlacement.Item1[0] + Compass.CurrentPlacement.Item1[1]) + " blocks");

#if DEBUG
            Console.WriteLine("Debugger waiting...");
            Console.ReadLine();
#endif
        }

        private string[] Week1_ParseInput()
        {
            var input = new StreamReader(@"Resource\Day1_Input.txt").ReadToEnd().Split(',').ToArray();

            var trimmedStrings = new List<string>();
            foreach (var str in input)
            {
                trimmedStrings.Add(str.Trim());
            }

            return trimmedStrings.ToArray();
        }
    }
}
