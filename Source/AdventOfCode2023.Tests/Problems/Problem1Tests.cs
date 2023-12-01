namespace AdventOfCode2023.Tests.Problems;

using AdventOfCode2023.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem1Tests
{
    private static string[] _inputOne = new[]
    {
        "1abc2",
        "pqr3stu8vwx",
        "a1b2c3d4e5f",
        "treb7uchet"
    };

    private static string[] _inputTwo = new[]
    {
        "two1nine",
        "eightwothree",
        "abcone2threexyz",
        "xtwone3four",
        "4nineeightseven2",
        "zoneight234",
        "7pqrstsixteen"
    };

    private static string[] _inputThree = new[]
    {
        "eighthree",
        "sevenine",
        "twone",
        "xtwone3four",
        "oneight"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem1.PartOne(_inputOne), Is.EqualTo(142));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem1.PartTwo(_inputTwo), Is.EqualTo(281));
        Assert.That(Problem1.PartTwo(_inputThree), Is.EqualTo(225));
    }
}