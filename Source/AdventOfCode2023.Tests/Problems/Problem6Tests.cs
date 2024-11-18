namespace AdventOfCode2023.Tests.Problems;

using AdventOfCode2023.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem6Tests
{
    private static readonly string[] TestInput = new[]
    {
        "Time:      7  15   30",
        "Distance:  9  40  200"
    };

    [Test]
    public void Part1()
    {
        Assert.That(Problem6.PartOne(TestInput), Is.EqualTo(288));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Problem6.PartTwo(TestInput), Is.EqualTo(71503));
    }
}