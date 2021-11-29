using System;
using System.IO;
using Xunit;

namespace _99Bottles.UnitTest;

public class SongUnitTests
{
    [Fact]
    public void Verse_ThrowsWhenBottleCountHigherThanMaxBottles() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () => ASong().Verse(bottleCount: SongLyrics.MaxBottleCount + 1));

    [Fact]
    public void Verse_ThrowsWhenBottleCountLowerThanZero() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () => ASong().Verse(bottleCount: -1));

    [Fact]
    public void Verse_NoMoreBottles()
    {
        string expectedNoBottleLyrics =
@"No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

        string actualNoBottleLyrics = ASong().Verse(bottleCount: 0);

        Assert.Equal(expectedNoBottleLyrics, actualNoBottleLyrics);
    }

    [Fact]
    public void Verse_OneBottle()
    {
        string expectedOneBottleLyrics =
@"1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.";

        string actualOneBottleLyrics = ASong().Verse(bottleCount: 1);

        Assert.Equal(expectedOneBottleLyrics, actualOneBottleLyrics);
    }

    [Fact]
    public void Verse_TwoBottles()
    {
        string expectedTwoBottlesLyrics =
@"2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.";

        string actualTwoBottlesLyrics = ASong().Verse(bottleCount: 2);

        Assert.Equal(expectedTwoBottlesLyrics, actualTwoBottlesLyrics);
    }

    [Fact]
    public void Verse_ThreeBottles()
    {
        string expectedThreeBottlesLyrics =
@"3 bottles of milk on the wall, 3 bottles of milk.
Take one down and pass it around, 2 bottles of milk on the wall.";

        string actualThreeBottlesLyrics = ASong().Verse(bottleCount: 3);

        Assert.Equal(expectedThreeBottlesLyrics, actualThreeBottlesLyrics);
    }

    [Fact]
    public void Verses_ThrowsWhenStartingBottleCountHigherThanMaxBottles() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () =>
                ASong().Verses(
                    startingBottleCount: SongLyrics.MaxBottleCount + 1,
                    endingBottleCount: 0));

    [Fact]
    public void Verses_ThrowsWhenStartingBottleCountLowerThanZero() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () =>
                ASong().Verses(
                    startingBottleCount: -1,
                    endingBottleCount: 0));

    [Fact]
    public void Verses_ThrowsWhenEndingBottleCountHigherThanMaxBottles() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () =>
                ASong().Verses(
                    startingBottleCount: SongLyrics.MaxBottleCount,
                    endingBottleCount: SongLyrics.MaxBottleCount + 1));

    [Fact]
    public void Verses_ThrowsWhenEndingBottleCountLowerThanZero() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            testCode: () =>
                ASong().Verses(
                    startingBottleCount: SongLyrics.MaxBottleCount,
                    endingBottleCount: -1));

    [Fact]
    public void Verses_ThrowsWhenEndingBottleCountHigherThanStartingBottleCount() =>
        Assert.Throws<ArgumentException>(
            testCode: () =>
                ASong().Verses(
                    startingBottleCount: 0,
                    endingBottleCount: SongLyrics.MaxBottleCount));

    [Fact]
    public void Verses_OneThroughZeroBottles()
    {
        string expectedOneThroughZeroBottleLyrics =
@"1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

        string actualOneThroughZeroBottleLyrics =
            ASong().Verses(startingBottleCount: 1, endingBottleCount: 0);

        Assert.Equal(
            expectedOneThroughZeroBottleLyrics,
            actualOneThroughZeroBottleLyrics);
    }

    [Fact]
    public void Verses_TwoThroughZeroBottles()
    {
        string expectedTwoThroughZeroBottlesLyrics =
@"2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.

1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

        string actualTwoThroughZeroBottlesLyrics =
            ASong().Verses(startingBottleCount: 2, endingBottleCount: 0);

        Assert.Equal(
            expectedTwoThroughZeroBottlesLyrics,
            actualTwoThroughZeroBottlesLyrics);
    }

    [Fact]
    public void Verses_ThreeThroughZeroBottles()
    {
        string expectedThreeThroughZeroBottlesLyrics =
@"3 bottles of milk on the wall, 3 bottles of milk.
Take one down and pass it around, 2 bottles of milk on the wall.

2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.

1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

        string actualThreeThroughZeroBottlesLyrics =
            ASong().Verses(startingBottleCount: 3, endingBottleCount: 0);

        Assert.Equal(
            expectedThreeThroughZeroBottlesLyrics,
            actualThreeThroughZeroBottlesLyrics);
    }

    [Fact]
    public void Verses_FourThroughOneBottles()
    {
        string expectedFourThroughOneBottlesLyrics =
@"4 bottles of milk on the wall, 4 bottles of milk.
Take one down and pass it around, 3 bottles of milk on the wall.

3 bottles of milk on the wall, 3 bottles of milk.
Take one down and pass it around, 2 bottles of milk on the wall.

2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.

1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.";

        string actualFourThroughOneBottlesLyrics =
            ASong().Verses(startingBottleCount: 4, endingBottleCount: 1);

        Assert.Equal(
            expectedFourThroughOneBottlesLyrics,
            actualFourThroughOneBottlesLyrics);
    }

    [Fact]
    public void Original_Verses_SevenThroughSixBottles()
    {
        string expectedSevenThroughSixBottlesLyrics =
@"7 bottles of milk on the wall, 7 bottles of milk.
Take one down and pass it around, 6 bottles of milk on the wall.

6 bottles of milk on the wall, 6 bottles of milk.
Take one down and pass it around, 5 bottles of milk on the wall.";

        string actualSevenThroughSixBottlesLyrics =
            OriginalSong().Verses(startingBottleCount: 7, endingBottleCount: 6);

        Assert.Equal(
            expectedSevenThroughSixBottlesLyrics,
            actualSevenThroughSixBottlesLyrics);
    }

    [Fact]
    public void SixPack_Verses_SevenThroughSixBottles()
    {
        string expectedSevenThroughSixBottlesLyrics =
@"7 bottles of milk on the wall, 7 bottles of milk.
Take one down and pass it around, 1 six-pack bottles of milk on the wall.

1 six-pack bottles of milk on the wall, 1 six-pack bottles of milk.
Take one down and pass it around, 5 bottles of milk on the wall.";

        string actualSevenThroughSixBottlesLyrics =
            SixPackSong().Verses(startingBottleCount: 7, endingBottleCount: 6);

        Assert.Equal(
            expectedSevenThroughSixBottlesLyrics,
            actualSevenThroughSixBottlesLyrics);
    }

    [Fact]
    public void Original_Recite()
    {
        string expected99BottlesLyrics = File.ReadAllText("song-original.txt");

        string actual99BottlesLyrics = OriginalSong().Recite();

        Assert.Equal(expected99BottlesLyrics, actual99BottlesLyrics);
    }

    [Fact]
    public void SixPack_Recite()
    {
        string expected99BottlesLyrics = File.ReadAllText("song-sixpack.txt");

        string actual99BottlesLyrics = SixPackSong().Recite();

        Assert.Equal(expected99BottlesLyrics, actual99BottlesLyrics);
    }

    private static Song ASong() =>
        new Song(SongLyrics.Original);

    private static Song OriginalSong() =>
        new Song(SongLyrics.Original);

    private static Song SixPackSong() =>
        new Song(SongLyrics.SixPack);
}
