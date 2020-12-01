using System.Linq;

namespace AdventOfCodeCs.Advent
{
    public class Year2020
    {
        public class Day1
        {
            public static long Part1(string input)
            {
                var parts = input.Split(',');
                var numbers = parts.Select(x => long.Parse(x)).OrderBy(x => x);
                for (var n = 0; n < numbers.Count(); n++)
                    for (var n2 = 1; n2 < numbers.Count(); n2++)
                    {
                        var first = numbers.ElementAt(n);
                        var second = numbers.ElementAt(n2);
                        if (first + second == 2020)
                            return first * second;
                    }
                return -1L;
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
                return 0;
            }

            public static long Part2(string input)
            {
                return 0;
            }
        }
    }
}
