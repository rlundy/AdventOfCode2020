using System;
using System.Collections.Generic;
using System.Diagnostics;
using AdventOfCodeCs.Advent;
using Xunit;
using static AdventOfCodeCs.Helpers;

namespace AdventOfCodeCs.Tests
{
    public class Year2020Tests
    {
        public class Day1
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("1721\n979\n366\n299\n675\n1456", 514579L)
                }.ApplyTests(Year2020.Day1.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("1721\n979\n366\n299\n675\n1456", 241861950L)
                }.ApplyTests(Year2020.Day1.Part2);
            }
        }

        public class Day2
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc", 2)
                }.ApplyTests(Year2020.Day2.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc", 1)
                }.ApplyTests(Year2020.Day2.Part2);
            }
        }

        public class Day3
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("..##.......\n#...#...#..\n.#....#..#.\n..#.#...#.#\n.#...##..#.\n..#.##.....\n.#.#.#....#\n.#........#\n#.##...#...\n#...##....#\n.#..#...#.#", 7)
                }.ApplyTests(Year2020.Day3.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("..##.......\n#...#...#..\n.#....#..#.\n..#.#...#.#\n.#...##..#.\n..#.##.....\n.#.#.#....#\n.#........#\n#.##...#...\n#...##....#\n.#..#...#.#", 336)
                }.ApplyTests(Year2020.Day3.Part2);
            }
        }

        public class Day4
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\nbyr:1937 iyr:2017 cid:147 hgt:183cm\n\niyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\nhcl:#cfa07d byr:1929\n\nhcl:#ae17e1 iyr:2013\neyr:2024\necl:brn pid:760753108 byr:1931\nhgt:179cm\n\nhcl:#cfa07d eyr:2025 pid:166559648\niyr:2011 ecl:brn hgt:59in", 2)
                }.ApplyTests(Year2020.Day4.Part1);
            }

            [Fact]
            void TestValidFields()
            {
                var validations = Year2020.Day4.Passport.GetValidations();
                var validFields = new List<(string, string)>
                {
                    ("byr","2002"),
                    ("hgt","60in"),
                    ("hgt","190cm"),
                    ("hcl","#123abc"),
                    ("ecl","brn"),
                    ("pid","000000001")

                };
                foreach (var (key, value) in validFields)
                {
                    Debug.Print($"Testing [{key}]:[{value}]...");
                    var validator = validations[key];
                    Assert.True(validator.IsValid(value));
                }
            }

            [Fact]
            void TestInvalidFields()
            {
                var validations = Year2020.Day4.Passport.GetValidations();
                var invalidFields = new List<(string, string)>
                {
                    ("byr","2003"),
                    ("hgt","190in"),
                    ("hgt","190"),
                    ("hcl","#123abz"),
                    ("hcl","123abc"),
                    ("ecl","wat"),
                    ("pid","0123456789")
                };
                foreach (var (key, value) in invalidFields)
                {
                    Debug.Print($"Testing [{key}]:[{value}]...");
                    var validator = validations[key];
                    Assert.False(validator.IsValid(value));
                }
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("eyr:1972 cid:100\nhcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926\n\niyr:2019\nhcl:#602927 eyr:1967 hgt:170cm\necl:grn pid:012533040 byr:1946\n\nhcl:dab227 iyr:2012\necl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277\n\nhgt:59cm ecl:zzz\neyr:2038 hcl:74454a iyr:2023\npid:3556412378 byr:2007" ,0),
                    ("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\nhcl:#623a2f\n\neyr:2029 ecl:blu cid:129 byr:1989\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm\n\nhcl:#888785\nhgt:164cm byr:2001 iyr:2015 cid:88\npid:545766238 ecl:hzl\neyr:2022\n\niyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719" ,4)
                }.ApplyTests(Year2020.Day4.Part2);
            }
        }

        public class Day5
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("FBFBBFFRLR", 357),
                    ("BFFFBBFRRR", 567),
                    ("FFFBBBFRRR", 119),
                    ("BBFFBBFRLL", 820)
                }.ApplyTests(Year2020.Day5.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                }.ApplyTests(Year2020.Day5.Part2);
            }
        }

        public class Day6
        {
            [Fact]
            void Part1()
            {
                new List<(string, long)>
                {
                    ("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 11)
                }.ApplyTests(Year2020.Day6.Part1);
            }

            [Fact]
            void Part2()
            {
                new List<(string, long)>
                {
                    ("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 6)
                }.ApplyTests(Year2020.Day6.Part2);
            }
        }

        [Fact]
        public void Solutions()
        {
            Banner(2020, 1);
            var input1 = PuzzleInput.Get(2020, 1);
            Console.WriteLine(Year2020.Day1.Part1(input1));
            Console.WriteLine(Year2020.Day1.Part2(input1));

            Banner(2020, 2);
            var input2 = PuzzleInput.Get(2020, 2);
            Console.WriteLine(Year2020.Day2.Part1(input2));
            Console.WriteLine(Year2020.Day2.Part2(input2));

            Banner(2020, 3);
            var input3 = PuzzleInput.Get(2020, 3);
            Console.WriteLine(Year2020.Day3.Part1(input3));
            Console.WriteLine(Year2020.Day3.Part2(input3));

            Banner(2020, 4);
            var input4 = PuzzleInput.Get(2020, 4);
            Console.WriteLine(Year2020.Day4.Part1(input4));
            Console.WriteLine(Year2020.Day4.Part2(input4));

            Banner(2020, 5);
            var input5 = PuzzleInput.Get(2020, 5);
            Console.WriteLine(Year2020.Day5.Part1(input5));
            Console.WriteLine(Year2020.Day5.Part2(input5));

            Banner(2020, 6);
            var input6 = PuzzleInput.Get(2020, 6);
            Console.WriteLine(Year2020.Day6.Part1(input6));
            Console.WriteLine(Year2020.Day6.Part2(input6));
        }
    }
}
