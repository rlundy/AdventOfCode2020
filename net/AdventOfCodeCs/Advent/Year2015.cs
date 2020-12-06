using System;
using System.Collections.Generic;
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

        public class Day2
        {
            static (int length, int width, int height) GetDimensions(string dimensionText)
            {
                var parts = dimensionText.Split('x');
                var len = int.Parse(parts[0]);
                var width = int.Parse(parts[1]);
                var height = int.Parse(parts[2]);
                return (len, width, height);
            }

            static int GetWrappingFeet(string dimensions)
            {
                var (length, width, height) = GetDimensions(dimensions);
                var lw = length * width;
                var wh = width * height;
                var lh = length * height;
                var slack = Math.Min(lw, Math.Min(wh, lh));
                return lw * 2 + wh * 2 + lh * 2 + slack;
            }

            public static long Part1(string input)
            {
                var wrappingFeet = 0;
                var eachPresent = input.Split('\n');
                foreach (var dimensions in eachPresent)
                    wrappingFeet += GetWrappingFeet(dimensions);
                return wrappingFeet;
            }

            static int GetRibbonFeet(string dimensions)
            {
                var (length, width, height) = GetDimensions(dimensions);
                var volume = length * width * height;
                var lwPerimeter = length * 2 + width * 2;
                var whPerimeter = width * 2 + height * 2;
                var lhPerimeter = length * 2 + height * 2;
                var smallestPerimeter = Math.Min(lwPerimeter, Math.Min(whPerimeter, lhPerimeter));
                return smallestPerimeter + volume;
            }

            public static long Part2(string input)
            {
                var ribbonFeet = 0;
                var eachPresent = input.Split('\n');
                foreach (var dimensions in eachPresent)
                    ribbonFeet += GetRibbonFeet(dimensions);
                return ribbonFeet;
            }
        }

        public class Day3
        {
            class DeliveryRecords
            {
                long x = 0;
                long y = 0;

                public HashSet<(long, long)> deliveries = new();

                public long DeliveryCount => deliveries.Count;

                public DeliveryRecords() => deliveries.Add((x, y));

                public void AddDelivery(long x, long y) => deliveries.Add((x, y));

                public void West() => AddDelivery(--x, y);
                public void East() => AddDelivery(++x, y);
                public void North() => AddDelivery(x, --y);
                public void South() => AddDelivery(x, ++y);
            }

            static void MakeDelivery(char ch, DeliveryRecords deliverer)
            {
                switch (ch)
                {
                    case '<':
                        deliverer.West();
                        break;
                    case '>':
                        deliverer.East();
                        break;
                    case '^':
                        deliverer.North();
                        break;
                    case 'v':
                        deliverer.South();
                        break;
                    default:
                        throw new InvalidOperationException($"Bad character: {ch}");
                }
            }

            public static long Part1(string input)
            {
                var deliveries = new DeliveryRecords();
                foreach (var ch in input)
                    MakeDelivery(ch, deliveries);
                return deliveries.DeliveryCount;
            }

            public static long Part2(string input)
            {
                var santaDeliveries = new DeliveryRecords();
                var roboDeliveries = new DeliveryRecords();
                var santaTurn = true;
                foreach (var ch in input)
                {
                    var deliverer = santaTurn ? santaDeliveries : roboDeliveries;
                    santaTurn = !santaTurn;
                    MakeDelivery(ch, deliverer);
                }
                return santaDeliveries.deliveries.Union(roboDeliveries.deliveries).Count();
            }
        }
    }
}
