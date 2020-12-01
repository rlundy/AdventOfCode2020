using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeCs
{
    public static class Helpers
    {
        public static void ApplyTests(this IEnumerable<(string, long)> inputs, Func<string, long> function)
        {
            foreach (var (input, expected) in inputs)
                Assert.Equal(expected, function(input));
        }
    }

    public class InputSet : List<(string, long)> { }
}
