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
    public class Day3Solution
    {
        private TriangleValidator _triangleValidator = new TriangleValidator();
        public Day3Solution()
        {
            Day3_ParseInputColumns();

            Console.WriteLine($"Number of valid triangles: {TriangleValidator.ValidTriangleCount}");
            Console.ReadLine();
        }

        private void Day3_ParseInputColumns()
        {
            var fileContent = File.ReadAllText(@"Resource\Day3_Input.txt");
            var parsedItems = fileContent.Split((string[]) null, StringSplitOptions.RemoveEmptyEntries);

            _triangleValidator.ValidateColumns(parsedItems);
        }

        private void Day3_ParseInputLines()
        {
            var fileContent = File.ReadLines(@"Resource\Day3_Input.txt");

            foreach (var line in fileContent)
            {
                _triangleValidator.ValidateLines(line);
            }
        }
    }
}
