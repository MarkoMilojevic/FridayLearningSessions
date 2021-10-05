using System;
using System.IO;
using Xunit;

namespace _99Bottles.UnitTest
{
    public class SongUnitTests
    {
        [Fact]
        public void Verse_ThrowsWhenBottleCountHigherThanMaxBottles() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verse(bottleCount: Song.MaxBottleCount + 1));

        [Fact]
        public void Verse_ThrowsWhenBottleCountLowerThanZero() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verse(bottleCount: -1));

        [Fact]
        public void Verse_NoMoreBottles()
        {
            string expectedNoBottleLyrics =
@"No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualNoBottleLyrics = Song.Verse(bottleCount: 0);

            Assert.Equal(expectedNoBottleLyrics, actualNoBottleLyrics);
        }

        [Fact]
        public void Verse_OneBottle()
        {
            string expectedOneBottleLyrics =
@"1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.";

            string actualOneBottleLyrics = Song.Verse(bottleCount: 1);

            Assert.Equal(expectedOneBottleLyrics, actualOneBottleLyrics);
        }

        [Fact]
        public void Verse_TwoBottles()
        {
            string expectedTwoBottlesLyrics =
@"2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.";

            string actualTwoBottlesLyrics = Song.Verse(bottleCount: 2);

            Assert.Equal(expectedTwoBottlesLyrics, actualTwoBottlesLyrics);
        }

        [Fact]
        public void Verse_ThreeBottles()
        {
            string expectedThreeBottlesLyrics =
@"3 bottles of milk on the wall, 3 bottles of milk.
Take one down and pass it around, 2 bottles of milk on the wall.";

            string actualThreeBottlesLyrics = Song.Verse(bottleCount: 3);

            Assert.Equal(expectedThreeBottlesLyrics, actualThreeBottlesLyrics);
        }

        [Fact]
        public void Verses_ThrowsWhenStartingBottleCountHigherThanMaxBottles() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verses(startingBottleCount: Song.MaxBottleCount + 1, endingBottleCount: 0));

        [Fact]
        public void Verses_ThrowsWhenStartingBottleCountLowerThanZero() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verses(startingBottleCount: -1, endingBottleCount: 0));

        [Fact]
        public void Verses_ThrowsWhenEndingBottleCountHigherThanMaxBottles() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verses(startingBottleCount: Song.MaxBottleCount, endingBottleCount: Song.MaxBottleCount + 1));

        [Fact]
        public void Verses_ThrowsWhenEndingBottleCountLowerThanZero() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                testCode: () => Song.Verses(startingBottleCount: Song.MaxBottleCount + 1, endingBottleCount: -1));

        [Fact]
        public void Verses_ThrowsWhenEndingBottleCountHigherThanStartingBottleCount() =>
            Assert.Throws<ArgumentException>(
                testCode: () => Song.Verses(startingBottleCount: 0, endingBottleCount: Song.MaxBottleCount));

        [Fact]
        public void Verses_OneThroughZeroBottles()
        {
            string expectedOneThroughZeroBottleLyrics =
@"1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualOneThroughZeroBottleLyrics =
                Song.Verses(startingBottleCount: 1, endingBottleCount: 0);

            Assert.Equal(expectedOneThroughZeroBottleLyrics, actualOneThroughZeroBottleLyrics);
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
                Song.Verses(startingBottleCount: 2, endingBottleCount: 0);

            Assert.Equal(expectedTwoThroughZeroBottlesLyrics, actualTwoThroughZeroBottlesLyrics);
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
                Song.Verses(startingBottleCount: 3, endingBottleCount: 0);

            Assert.Equal(expectedThreeThroughZeroBottlesLyrics, actualThreeThroughZeroBottlesLyrics);
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
                Song.Verses(startingBottleCount: 4, endingBottleCount: 1);

            Assert.Equal(expectedFourThroughOneBottlesLyrics, actualFourThroughOneBottlesLyrics);
        }

        [Fact]
        public void Recite()
        {
            string expected99BottlesLyrics = File.ReadAllText("song.txt");

            string actual99BottlesLyrics = Song.Recite();

            Assert.Equal(expected99BottlesLyrics, actual99BottlesLyrics);
        }
    }
}
