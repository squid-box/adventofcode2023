namespace AdventOfCode2023.Problems;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2023/day/6">Day 6</a>.
/// </summary>
public class Problem6(InputDownloader inputDownloader) : ProblemBase(6, inputDownloader)
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

    internal static int PartOne(IList<string> input)
    {
        var times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].Select(v => Convert.ToInt32(v)).ToList();
        var recordDistance = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].Select(v => Convert.ToInt32(v)).ToList();

        var product = 1; 

        for (var race = 0; race < times.Count(); race++)
        {
            product *= NumberOfWaysToBeatRecord(times[race], recordDistance[race]);
        }

        return product;
    }

    internal static long PartTwo(IList<string> input)
    {
        var time = Convert.ToInt64(string.Join("", input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..]));
        var recordDistance = Convert.ToInt64(string.Join("", input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..]));

        return NumberOfWaysToBeatRecord(time, recordDistance);
    }

    private static int NumberOfWaysToBeatRecord(long time, long recordDistance)
    {
        var numberOfWaysToBeatRecord = 0;

        for (var secondsToHoldButton = 1; secondsToHoldButton < time; secondsToHoldButton++)
        {
            var timeRemaining = time - secondsToHoldButton;

            if (timeRemaining * secondsToHoldButton > recordDistance)
            {
                numberOfWaysToBeatRecord++;
            }
        }

        return numberOfWaysToBeatRecord;
    }
}