using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace AdventOfCodeCs
{
    public static class Helpers
    {
        public static void ApplyTests<TIn, TOut>(this IEnumerable<(TIn, TOut)> inputs, Func<TIn, TOut> function)
        {
            foreach (var (input, expected) in inputs)
                Assert.Equal(expected, function(input));
        }

        public static void Banner(long year, long day) => Debug.Print($"*** Year {year} Day {day} ***");
    }

    public static class PuzzleInput
    {
        public static string Get(long year, long day)
        {
            var currentDir = new DirectoryInfo(".");
            Debug.Print($"Current folder: {currentDir.FullName}");
            var folder = new DirectoryInfo(@"..\..\..\..\..\PuzzleInput");
            var expectedFileName = $"y{year}d{day.ToString("00")}.txt";
            var fileName = Path.Combine(folder.FullName, expectedFileName);
            var file = new FileInfo(fileName);
            return File.ReadAllText(file.FullName);
        }
    }
}
