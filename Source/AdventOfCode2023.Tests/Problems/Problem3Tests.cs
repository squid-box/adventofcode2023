namespace AdventOfCode2023.Tests.Problems;

using AdventOfCode2023.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem3Tests
{
    private readonly string[] _testInput = new[]
    {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    };

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem3.PartOne(_testInput), Is.EqualTo(4361));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem3.PartTwo(_testInput), Is.EqualTo(467835));
    }
}