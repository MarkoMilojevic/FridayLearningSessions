﻿using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class SongInline
{
    [Benchmark]
    public void Recite() =>
        Verses(start: 1_000_000, end: 0);

    public void Verses(int start, int end)
    {
        for (int i = start; i >= end; i--)
        {
            string verse = this.Verse(i) + Environment.NewLine;
        }
    }

    public string Verse(int number) =>
        number switch
        {
            0 =>
            $"No more bottles of milk on the wall, {Environment.NewLine}" +
            $"no more bottles of milk.{Environment.NewLine}" +
            $"Go to the store and buy some more{Environment.NewLine}" +
            $"99 bottles of milk on the wall.",
            1 =>
            $"1 bottle of milk on the wall, {Environment.NewLine}" +
            $"1 bottle of milk.{Environment.NewLine}" +
            $"Take it down and pass it around{Environment.NewLine}" +
            $"no more bottles of milk on the wall.",
            2 =>
            $"2 bottles of milk on the wall, {Environment.NewLine}" +
            $"2 bottles of milk.{Environment.NewLine}" +
            $"Take one down and pass it around{Environment.NewLine}" +
            $"1 bottle of milk on the wall.",
            _ =>
            $"{number} bottles of milk on the wall, {Environment.NewLine}" +
            $"{number} bottles of milk.{Environment.NewLine}" +
            $"Take one down and pass it around{Environment.NewLine}" +
            $"{number - 1} bottles of milk on the wall.",
        };
}
