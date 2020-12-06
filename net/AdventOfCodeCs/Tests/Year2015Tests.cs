using System.Collections.Generic;
using AdventOfCodeCs.Advent;
using Xunit;

using static AdventOfCodeCs.Helpers;
using static System.Console;

namespace AdventOfCodeCs.Tests
{
    public class Year2015Tests
    {
        public class Day1
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("(())", 0L),
                    ("()()", 0L),
                    ("(((", 3L),
                    ("(()(()(", 3L),
                    ("))(((((", 3L),
                    ("())", -1L),
                    ("))(", -1L),
                    (")))", -3L),
                    (")())())", -3L)
                }.ApplyTests(Year2015.Day1.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    (")", 1),
                    ("()())", 5)
                }.ApplyTests(Year2015.Day1.Part2);
            }
        }

        public class Day2
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("2x3x4", 58),
                    ("1x1x10", 43)
                }.ApplyTests(Year2015.Day2.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("2x3x4", 34),
                    ("1x1x10", 14)
                }.ApplyTests(Year2015.Day2.Part2);
            }
        }

        public class Day3
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    (">", 2),
                    ("^>v<", 4),
                    ("^v^v^v^v^v", 2)
                }.ApplyTests(Year2015.Day3.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("^v", 3),
                    ("^>v<", 3),
                    ("^v^v^v^v^v", 11)
                }.ApplyTests(Year2015.Day3.Part2);
            }
        }

        [Fact]
        void Solutions()
        {
            Banner(2015, 1);
            var input1 = PuzzleInput.Get(2015, 1);
            WriteLine(Year2015.Day1.Part1(input1));
            WriteLine(Year2015.Day1.Part2(input1));

            Banner(2015, 2);
            var input2 = PuzzleInput.Get(2015, 2);
            WriteLine(Year2015.Day2.Part1(input2));
            WriteLine(Year2015.Day2.Part2(input2));

            Banner(2015, 3);
            var input3 = PuzzleInput.Get(2015, 3);
            WriteLine(Year2015.Day3.Part1(input3));
            WriteLine(Year2015.Day3.Part2(input3));

        }
    }
}