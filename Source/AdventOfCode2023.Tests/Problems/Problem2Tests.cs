namespace AdventOfCode2023.Tests.Problems;

using System.Collections.Generic;
using AdventOfCode2023.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem2Tests
{
    private readonly string[] _testInput = new[]
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem2.PartOne(_testInput), Is.EqualTo(8));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem2.PartTwo(_testInput), Is.EqualTo(2286));
    }
}