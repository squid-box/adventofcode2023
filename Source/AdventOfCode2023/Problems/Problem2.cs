namespace AdventOfCode2023.Problems;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2023.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2023/day/2">Day 2</a>.
/// </summary>
public class Problem2(InputDownloader inputDownloader) : ProblemBase(2, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    public static int PartOne(IEnumerable<string> input)
    {
        var sum = 0;

        foreach (var game in input)
        {
            var (possible, id) = IsGamePossible(game, 12, 13, 14);

            if (possible)
            {
                sum += id;
            }
        }

        return sum;
    }

    public static int PartTwo(IEnumerable<string> input)
    {
        return input.Sum(FindGamePower);
    }

    private static (bool, int) IsGamePossible(string game, int maxRed, int maxGreen, int maxBlue)
    {
        var gameId = Regex.Match(game, @"Game (?<id>\d+):").Groups["id"].Value.ToInt();

        foreach (var set in game.Split(';'))
        {
            var red = Regex.Match(set, @"(?<number>\d+) red").Groups["number"].Value;
            var green= Regex.Match(set, @"(?<number>\d+) green").Groups["number"].Value;
            var blue = Regex.Match(set, @"(?<number>\d+) blue").Groups["number"].Value;

            if (!string.IsNullOrEmpty(red))
            {
                if (red.ToInt() > maxRed)
                {
                    return (false, gameId);
                }
            }

            if (!string.IsNullOrEmpty(green))
            {
                if (green.ToInt() > maxGreen)
                {
                    return (false, gameId);
                }
            }

            if (!string.IsNullOrEmpty(blue))
            {
                if (blue.ToInt() > maxBlue)
                {
                    return (false, gameId);
                }
            }
        }

        return (true, gameId);
    }

    private static int FindGamePower(string game)
    {
        var minRed = 0;
        var minGreen = 0;
        var minBlue = 0;

        foreach (var set in game.Split(';'))
        {
            var red = Regex.Match(set, @"(?<number>\d+) red").Groups["number"].Value;
            var green = Regex.Match(set, @"(?<number>\d+) green").Groups["number"].Value;
            var blue = Regex.Match(set, @"(?<number>\d+) blue").Groups["number"].Value;

            if (!string.IsNullOrEmpty(red))
            {
                var number = red.ToInt();

                if (number > minRed)
                {
                    minRed = number;
                }
            }

            if (!string.IsNullOrEmpty(green))
            {
                var number = green.ToInt();

                if (number > minGreen)
                {
                    minGreen = number;
                }
            }

            if (!string.IsNullOrEmpty(blue))
            {
                var number = blue.ToInt();

                if (number > minBlue)
                {
                    minBlue = number;
                }
            }
        }

        return minRed * minGreen * minBlue;
    }
}