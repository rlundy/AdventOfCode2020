using System.Linq;

namespace AdventOfCodeCs.Advent
{
    class Year2015
    {
        public class Day1
        {
            public static long Part1(string input)
            {
                var up = input.Count(x => x.Equals('('));
                var down = input.Count(x => x.Equals(')'));
                return up - down;
            }

            public static long Part2(string input)
            {
                var floor = 0;
                var pos = 0;
                input.TakeWhile(x =>
                {
                    pos++;
                    floor += x == '(' ? 1 : -1;
                    return floor >= 0;
                }).ToList();
                return pos;
            }
        }
    }
}
