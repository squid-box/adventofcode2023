namespace AdventOfCode2023.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2023.Utils;
using AdventOfCode2023.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2023/day/3">Day 3</a>.
/// </summary>
public class Problem3(InputDownloader inputDownloader) : ProblemBase(3, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input.ToList());
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input.ToList());
    }

    public static int PartOne(IList<string> input)
    {
        var schematic = new Dictionary<Coordinate, char>();

        for (var y = 0; y < input.Count; y++)
        {
            var line = input[y];

            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '.')
                {
                    continue;
                }

                schematic.Add(new Coordinate(x, y), line[x]);
            }
        }

        var visited = new HashSet<Coordinate>();
        var parts = new HashSet<Part>();

        foreach (var point in schematic)
        {
            if (visited.Contains(point.Key))
            {
                continue;
            }

            visited.Add(point.Key);

            if (char.IsDigit(point.Value))
            {
                var part = new Part();
                part.AddNumber(point.Value);

                foreach (var neighbor in point.Key.GetNeighbors())
                {
                    if (schematic.TryGetValue(neighbor, out var value))
                    {
                        if (!char.IsDigit(value))
                        {
                            part.Symbol = (neighbor, value);
                            break;
                        }
                    }
                }

                var checkingCoordinate = new Coordinate(point.Key.X + 1, point.Key.Y);

                while (schematic.ContainsKey(checkingCoordinate))
                {
                    visited.Add(checkingCoordinate);

                    if (!char.IsDigit(schematic[checkingCoordinate]))
                    {
                        break;
                    }

                    foreach (var neighbor in checkingCoordinate.GetNeighbors())
                    {
                        if (schematic.TryGetValue(neighbor, out var value))
                        {
                            if (!char.IsDigit(value))
                            {
                                part.Symbol = (neighbor, value);
                                break;
                            }
                        }
                    }

                    part.AddNumber(schematic[checkingCoordinate]);
                    checkingCoordinate = new Coordinate(checkingCoordinate.X + 1, checkingCoordinate.Y);
                }

                parts.Add(part);
            }
        }

        var sum = 0;

        foreach (var part in parts)
        {
            if (part.Symbol.Item1 != null)
            {
                sum += part.Number;
            }
        }

        return sum;
    }

    private class Part
    {
        private string _number;

        public void AddNumber(char digit)
        {
            _number = $"{_number}{digit}";
        }

        public int Number => _number.ToInt();

        public (Coordinate, char) Symbol { get; set; }
    }

    public static int PartTwo(IList<string> input)
    {
        var schematic = new Dictionary<Coordinate, char>();

        for (var y = 0; y < input.Count; y++)
        {
            var line = input[y];

            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '.')
                {
                    continue;
                }

                schematic.Add(new Coordinate(x, y), line[x]);
            }
        }

        var visited = new HashSet<Coordinate>();
        var parts = new HashSet<Part>();

        foreach (var point in schematic)
        {
            if (visited.Contains(point.Key))
            {
                continue;
            }

            visited.Add(point.Key);

            if (char.IsDigit(point.Value))
            {
                var part = new Part();
                part.AddNumber(point.Value);

                foreach (var neighbor in point.Key.GetNeighbors())
                {
                    if (schematic.TryGetValue(neighbor, out var value))
                    {
                        if (!char.IsDigit(value))
                        {
                            part.Symbol = (neighbor, value);
                            break;
                        }
                    }
                }

                var checkingCoordinate = new Coordinate(point.Key.X + 1, point.Key.Y);

                while (schematic.ContainsKey(checkingCoordinate))
                {
                    visited.Add(checkingCoordinate);

                    if (!char.IsDigit(schematic[checkingCoordinate]))
                    {
                        break;
                    }

                    foreach (var neighbor in checkingCoordinate.GetNeighbors())
                    {
                        if (schematic.TryGetValue(neighbor, out var value))
                        {
                            if (!char.IsDigit(value))
                            {
                                part.Symbol = (neighbor, value);
                                break;
                            }
                        }
                    }

                    part.AddNumber(schematic[checkingCoordinate]);
                    checkingCoordinate = new Coordinate(checkingCoordinate.X + 1, checkingCoordinate.Y);
                }

                parts.Add(part);
            }
        }

        var sum = 0;

        var used = new HashSet<Part>();

        foreach (var part in parts.Where(p => p.Symbol.Item2 == '*'))
        {
            if (used.Contains(part))
            {
                continue;
            }

            var others = parts.Where(o => Equals(o.Symbol.Item1, part.Symbol.Item1) && !Equals(o?.Number, part?.Number)).ToList();

            if (others.Count != 1)
            {
                continue;
            }

            sum += part.Number * others[0].Number;
            used.Add(part);
            used.Add(others[0]);
        }

        return sum;
    }
}