using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeCs.Tests
{
    public class Common
    {
        public static void ApplyTest(IEnumerable<(string, int)> inputs, Func<string, int> function)
        {
            foreach (var (input, expected) in inputs)
            {
                var actual = function(input);
                Assert.Equal(expected, actual);
            }
        }
    }
}
