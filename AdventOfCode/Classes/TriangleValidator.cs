using System;

namespace AdventOfCode.Classes
{
    public class TriangleValidator
    {
        public static int ValidTriangleCount { get; set; }

        private static int InputIndex;

        public void ValidateColumns(string[] input)
        {
            int i = 0;

            int a;
            int b;
            int c;
            while (InputIndex < input.Length)
            {
                int.TryParse(input[InputIndex], out a);
                int.TryParse(input[InputIndex + 3], out b);
                int.TryParse(input[InputIndex + 6], out c);

                Validate(a, b, c);

                i++;
                if(i == 3)
                {
                    InputIndex = InputIndex + 7;
                    i = 0;
                    continue;
                }

                InputIndex++;
            }
        }

        public void ValidateLines(string input)
        {
            var parsedItems = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(parsedItems[0]);
            var b = int.Parse(parsedItems[1]);
            var c = int.Parse(parsedItems[2]);

            Validate(a,b,c);
        }

        private void Validate(int a, int b, int c)
        {
            if (a == 0 || b == 0 || c == 0) return;

            if (a < b + c && b < a + c && c < a + b) ValidTriangleCount++;
        }
    }
}
