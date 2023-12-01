namespace AdventOfCode2023.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2023.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2023/day/1">Day 1</a>.
/// </summary>
public class Problem1(InputDownloader inputDownloader) : ProblemBase(1, inputDownloader)
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

        foreach (var line in input)
        {
            var firstDigit = line.First(char.IsDigit);
            var lastDigit = line.Last(char.IsDigit);

            sum += $"{firstDigit}{lastDigit}".ToInt();
        }

        return sum;
    }

    public static int PartTwo(IEnumerable<string> input)
    {
        var sum = 0;

        foreach (var line in input)
        {
            var newLine = line
                .Replace("one", "o1e")
                .Replace("two", "t2o")
                .Replace("three", "t3ree")
                .Replace("four", "f4ur")
                .Replace("five", "f5ive")
                .Replace("six", "s6x")
                .Replace("seven", "s7ven")
                .Replace("eight", "e8ght")
                .Replace("nine", "n9ne");

            var firstDigit = newLine.First(char.IsDigit);
            var lastDigit = newLine.Last(char.IsDigit);

            sum += $"{firstDigit}{lastDigit}".ToInt();
        }

        return sum;
    }
}