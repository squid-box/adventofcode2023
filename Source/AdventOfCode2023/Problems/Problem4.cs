namespace AdventOfCode2023.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2023.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2023/day/4">Day 4</a>.
/// </summary>
public class Problem4(InputDownloader inputDownloader) : ProblemBase(4, inputDownloader)
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
        var cards = input.Select(line => new Card(line)).ToList();

        return cards.Sum(card => card.GetScore());
    }

    public static int PartTwo(IEnumerable<string> input)
    {
        var originalCards = input.Select(line => new Card(line)).ToDictionary(card => card.Number);

        var cardCount = originalCards.ToDictionary(card => card.Key, _ => 1);

        foreach (var card in originalCards.Values)
        {
            for (var i = 1; i <= card.Matches; i++)
            {
                cardCount[card.Number + i] += cardCount[card.Number];
            }
        }

        return cardCount.Sum(card => card.Value);
    }

    private class Card
    {
        public Card(string input)
        {
            Number = Regex.Match(input, @"Card\s+(?<number>\d+):").Groups["number"].Value.ToInt();

            var split = input.Split(':')[1].Split('|');

            var winningNumbers = split[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).AsInt();
            var yourNumbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).AsInt();

            Matches = yourNumbers.Intersect(winningNumbers).Count();
        }

        public int Number { get; }

        public int Matches { get; }

        public int GetScore()
        {
            if (Matches == 0)
            {
                return 0;
            }

            var score = 1;

            for (var i = 1; i < Matches; i++)
            {
                score *= 2;
            }

            return score;
        }
    }
}