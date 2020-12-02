using System;
using System.Collections.Generic;
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
    }
}
