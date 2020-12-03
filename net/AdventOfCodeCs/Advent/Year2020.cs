using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeCs.Advent
{
    public class Year2020
    {
        public class Day1
        {
            public static long Part1(string input)
            {
                var numbers = input
                    .Split(',')
                    .Select(x => long.Parse(x));
                var matchingPair = numbers
                    .SelectMany(x => numbers, (x, y) => new { x, y })
                    .First(pair => pair.x + pair.y == 2020);
                return matchingPair.x * matchingPair.y;
            }

            public static long Part2(string input)
            {
                var parts = input.Split(',');
                var numbers = parts.Select(x => long.Parse(x)).OrderBy(x => x);
                for (var n = 0; n < numbers.Count(); n++)
                    for (var n2 = 1; n2 < numbers.Count(); n2++)
                        for (var n3 = 2; n3 < numbers.Count(); n3++)
                        {
                            var first = numbers.ElementAt(n);
                            var second = numbers.ElementAt(n2);
                            var third = numbers.ElementAt(n3);
                            if (first + second + third == 2020)
                                return first * second * third;
                        }
                return -1L;
            }
        }

        public class Day2
        {
            public static long Part1(string input)
            {
                var totalValid = 0;
                var lines = input.Split(',');
                foreach (var line in lines)
                {
                    var parts = line.Split(' ');

                    var range = parts[0];
                    var letter = parts[1];
                    var password = parts[2];

                    letter = letter.Replace(":", string.Empty);
                    var rangeParts = range.Split('-');
                    var lower = int.Parse(rangeParts[0]);
                    var upper = int.Parse(rangeParts[1]);
                    var actualCount = password.Count(x => x.ToString() == letter);
                    if (lower <= actualCount && actualCount <= upper)
                        totalValid++;
                }
                return totalValid;
            }

            public static long Part2(string input)
            {
                var totalValid = 0;
                var lines = input.Split(',');
                foreach (var line in lines)
                {
                    var parts = line.Split(' ');

                    var positions = parts[0];
                    var letter = parts[1];
                    var password = parts[2];

                    letter = letter.Replace(":", string.Empty);
                    var posParts = positions.Split('-');
                    var pos1 = int.Parse(posParts[0]);
                    var pos2 = int.Parse(posParts[1]);
                    password = $" {password}";
                    var pos1valid = password[pos1].ToString() == letter;
                    var pos2valid = password[pos2].ToString() == letter;
                    if (pos1valid || pos2valid)
                        if (!(pos1valid && pos2valid))
                            totalValid++;
                }
                return totalValid;
            }
        }

        public class Day3
        {
            record Position
            {
                public int X { get; set; } = 0;
                public int Y { get; set; } = 0;

                public void AddSlope(Slope slope)
                {
                    X += slope.X;
                    Y += slope.Y;
                }
                public void Wrap(int length)
                {
                    if (X >= length)
                        X -= length;
                }
            }

            record Slope(int X, int Y) { }

            static long CountTrees(string input, Slope slope)
            {
                var treeCount = 0L;
                var pos = new Position();
                var lines = input.Split(',').ToList();
                var length = lines[0].Length;
                while (pos.Y < lines.Count)
                {
                    var ch = lines[pos.Y][pos.X];
                    if (ch == '#')
                        treeCount++;
                    pos.AddSlope(slope);
                    pos.Wrap(length);
                }

                return treeCount;
            }

            public static long Part1(string input) =>
                CountTrees(input, new Slope(3, 1));

            public static long Part2(string input)
            {
                var treeCounts = new List<long> { 0, 0, 0, 0, 0 };
                var slopes = new List<Slope> { new Slope(1, 1), new Slope(3, 1), new Slope(5, 1), new Slope(7, 1), new Slope(1, 2) };
                for (var s = 0; s < slopes.Count; s++)
                    treeCounts[s] = CountTrees(input, slopes[s]);
                var treeProduct = 1L;
                foreach (var tc in treeCounts)
                    treeProduct *= tc;
                return treeProduct;
            }
        }

        public class Day4
        {
            public static long Part1(string input)
            {
                return 0;
            }

            public static long Part2(string input)
            {
                return 0;
            }
        }
    }
}
