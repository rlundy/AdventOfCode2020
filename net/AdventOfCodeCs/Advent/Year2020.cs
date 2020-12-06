using System;
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
                    .Split('\n')
                    .Select(x => long.Parse(x));
                var matchingPair = numbers
                    .SelectMany(x => numbers, (x, y) => new { x, y })
                    .First(pair => pair.x + pair.y == 2020);
                return matchingPair.x * matchingPair.y;
            }

            public static long Part2(string input)
            {
                var parts = input.Split('\n');
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
                var lines = input.Split('\n');
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
                var lines = input.Split('\n');
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
                var lines = input.Split('\n').ToList();
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
                var validPassports = 0L;
                var passports = input.Split("\n\n").Select(x => new Passport(x));
                foreach (var p in passports)
                    if (p.HasAllRequiredFields())
                        validPassports++;
                return validPassports;
            }

            public class Passport
            {
                readonly Dictionary<string, string> passportData = new();
                readonly List<string> requiredFields = new() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
                readonly Dictionary<string, Validation> validations = GetValidations();

                public Passport(string input)
                {
                    var separators = new string[] { " ", "\n" };
                    var fieldsValues = input.Split(separators, StringSplitOptions.None);
                    foreach (var fv in fieldsValues)
                    {
                        var parts = fv.Split(":");
                        passportData.Add(parts[0], parts[1]);
                    }
                }

                public static Dictionary<string, Validation> GetValidations()
                {
                    var validations = new Dictionary<string, Validation>();
                    validations.Add("byr", new Validation(value =>
                    {
                        return Validation.IsInRange(value, 1920, 2002);
                    }));
                    validations.Add("iyr", new Validation(value =>
                    {
                        return Validation.IsInRange(value, 2010, 2020);
                    }));
                    validations.Add("eyr", new Validation(value =>
                    {
                        return Validation.IsInRange(value, 2020, 2030);
                    }));
                    validations.Add("hgt", new Validation(value =>
                    {
                        if (value.EndsWith("cm"))
                        {
                            var isValid = int.TryParse(value.Replace("cm", string.Empty), out var cmHeight);
                            if (!isValid)
                                return false;
                            return Validation.IsInRange(cmHeight, 150, 193);
                        }
                        else if (value.EndsWith("in"))
                        {
                            var isValid = int.TryParse(value.Replace("in", string.Empty), out var inHeight);
                            if (!isValid)
                                return false;
                            return Validation.IsInRange(inHeight, 59, 76);
                        }
                        else
                            return false;
                    }));
                    validations.Add("hcl", new Validation(value =>
                    {
                        if (!value.StartsWith('#'))
                            return false;
                        for (var i = 1; i < value.Length; i++)
                        {
                            var ch = value[i];
                            if (!"abcdef0123456789".Contains(ch))
                                return false;
                        }
                        return true;
                    }));
                    validations.Add("ecl", new Validation(value =>
                    {
                        var validValues = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        return validValues.Contains(value);
                    }));
                    validations.Add("pid", new Validation(value =>
                    {
                        if (value.Length != 9)
                            return false;
                        foreach (var ch in value)
                            if (!"0123456789".Contains(ch))
                                return false;
                        return true;
                    }));
                    return validations;
                }

                public bool HasAllRequiredFields()
                {
                    foreach (var req in requiredFields)
                        if (!passportData.ContainsKey(req))
                            return false;
                    return true;
                }

                public bool IsValid()
                {
                    foreach (var field in requiredFields)
                    {
                        var validator = validations[field];
                        if (!passportData.TryGetValue(field, out var value))
                            return false;
                        if (!validator.IsValid(value))
                            return false;
                    }
                    return true;
                }
            }

            public record Validation(Func<string, bool> ValidationFunction)
            {
                public bool IsValid(string fieldValue) => ValidationFunction(fieldValue);
                public static bool IsInRange(string valueText, int from, int to)
                {
                    var isValid = int.TryParse(valueText, out var value);
                    if (!isValid)
                        return false;
                    return IsInRange(value, from, to);
                }
                public static bool IsInRange(int value, int from, int to)
                {
                    return from <= value && value <= to;
                }
            }

            public static long Part2(string input)
            {
                var passports = input.Split("\n\n").Select(x => new Passport(x));
                return passports.Count(x => x.IsValid());
            }

            record ValidRange(int From, int To) { }
        }

        public class Day5
        {
            static long GetSeatID(string seatPartitioning)
            {
                var rows = seatPartitioning.Where(x => x == 'F' || x == 'B');
                var columns = seatPartitioning.Where(x => x == 'L' || x == 'R');
                var allSeats = new List<int>(Enumerable.Range(0, 128));
                var allColumns = new List<int>(Enumerable.Range(0, 8));
                foreach (var row in rows)
                {
                    var count = allSeats.Count / 2;
                    switch (row)
                    {
                        case 'F':
                            allSeats.RemoveRange(allSeats.Count / 2, count);
                            break;
                        case 'B':
                            allSeats.RemoveRange(0, count);
                            break;
                        default:
                            throw new InvalidOperationException($"Bad row: {row}");
                    }
                }
                var seat = allSeats[0];
                foreach (var col in columns)
                {
                    var count = allColumns.Count / 2;
                    switch (col)
                    {
                        case 'L':
                            allColumns.RemoveRange(allColumns.Count / 2, count);
                            break;
                        case 'R':
                            allColumns.RemoveRange(0, count);
                            break;
                        default:
                            throw new InvalidOperationException($"Bad column: {col}");
                    }
                }
                var column = allColumns[0];
                var seatID = seat * 8 + column;
                return seatID;
            }

            public static long Part1(string input)
            {
                return input
                    .Split('\n')
                    .Select(x => GetSeatID(x))
                    .Max();
            }

            public static long Part2(string input)
            {
                var allSeatIDs = input
                    .Split('\n')
                    .Select(x => GetSeatID(x))
                    .OrderBy(x => x)
                    .ToList();
                for (var id = 0; id < allSeatIDs.Count - 1; id++)
                {
                    var thisID = allSeatIDs[id];
                    var nextID = allSeatIDs[id + 1];
                    if (nextID - thisID == 2)
                        return thisID + 1;
                }
                return int.MinValue;
            }
        }

        public class Day6
        {
            public static long Part1(string input)
            {
                return input
                    .Split("\n\n")
                    .Aggregate(0, (accumulator, group) => accumulator += string.Join(string.Empty, group.Split('\n'))
                    .Distinct()
                    .Count());
            }

            public static long Part2(string input)
            {
                var yeses = 0;
                var groups = input.Split("\n\n");
                foreach (var group in groups)
                {
                    var allAnswers = "abcdefghijklmnopqrstuvwxyz".AsEnumerable().ToList();
                    var answerSets = group.Split('\n');
                    foreach (var answerSet in answerSets)
                        allAnswers.RemoveAll(x => !answerSet.Contains(x));
                    yeses += allAnswers.Count;
                }
                return yeses;
            }
        }
    }
}
