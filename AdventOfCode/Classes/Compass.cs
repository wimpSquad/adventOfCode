using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Classes
{
    public class Compass
    {
        public static Tuple<int[],Direction> CurrentPlacement { get; private set; } = new Tuple<int[], Direction>(new []{0,0},Direction.North);

        public void Turn(string input)
        {
            switch (input.ToLower().Contains("r"))
            {
                case true:
                    CurrentPlacement = new Tuple<int[], Direction>(CurrentPlacement.Item1, Steer(true));
                    break;
                case false:
                    CurrentPlacement = new Tuple<int[], Direction>(CurrentPlacement.Item1, Steer(false));
                    break;
            }

            CurrentPlacement = new Tuple<int[], Direction>(Drive(input), CurrentPlacement.Item2); // steer must take place first, to know which direction to increment
        }

        private Direction Steer(bool direction) // R = true, L = false
        {
            var newDirection = Direction.North;
            switch (direction)
            {
                case true:
                    switch (CurrentPlacement.Item2)
                    {
                        case Direction.North:
                            newDirection = Direction.East;
                            break;
                        case Direction.East:
                            newDirection = Direction.South;
                            break;
                        case Direction.South:
                            newDirection = Direction.West;
                            break;
                        case Direction.West:
                            newDirection = Direction.North;
                            break;
                    }
                break;
                case false:
                    switch (CurrentPlacement.Item2)
                    {
                        case Direction.North:
                            newDirection = Direction.West;
                            break;
                        case Direction.East:
                            newDirection = Direction.North;
                            break;
                        case Direction.South:
                            newDirection = Direction.East;
                            break;
                        case Direction.West:
                            newDirection = Direction.South;
                            break;
                    }
                break;
            }
            return newDirection;
        }

        private int[] Drive(string input)
        {
            int distance;
            int.TryParse(input.Replace("R", "").Replace("L", ""), out distance);

            var currentNorth = CurrentPlacement.Item1[0];
            var currentEast = CurrentPlacement.Item1[1];

            IterateAndCapture(distance);

            switch (CurrentPlacement.Item2)
            {
                case Direction.North:
                    currentNorth += distance;
                    break;
                case Direction.East:
                    currentEast += distance;
                    break;
                case Direction.South:
                    currentNorth -= distance;
                break;
                case Direction.West:
                    currentEast -= distance;
                break;
            }
            return new[]
            {
                currentNorth,
                currentEast
            };
        }

        private List<Tuple<int,int>> _visitedLocations = new List<Tuple<int, int>>();

        private void IterateAndCapture(int distance)
        {
            var currentNorth = CurrentPlacement.Item1[0];
            var currentEast = CurrentPlacement.Item1[1];
            var direction = CurrentPlacement.Item2;

            while (distance > 0)
            {
                if (_visitedLocations.Contains(new Tuple<int, int>(currentNorth, currentEast)))
                {
                    Console.WriteLine($"The first place visited twice is {currentNorth}, {currentEast} and is " + (Math.Abs(currentNorth) + Math.Abs(currentEast)) + " blocks away.");
                    Console.ReadLine();
                }
                _visitedLocations.Add(new Tuple<int, int>(currentNorth, currentEast));
                switch (direction)
                {
                        case Direction.North:
                            currentNorth += 1;
                            break;
                        case Direction.East:
                            currentEast += 1;
                            break;
                        case Direction.South:
                            currentNorth -= 1;
                            break;
                        case Direction.West:
                            currentEast -= 1;
                            break;
                }
                distance -= 1;
            }
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
