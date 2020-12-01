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
        }
    }
}
