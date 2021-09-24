using System;
using System.IO;
using Xunit;

namespace _99Bottles.UnitTest
{
    public class SongTests
    {
        [Fact]
        public void NoMoreBottles()
        {
            string expectedNoBottleLyrics =
@"No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualNoBottleLyrics = Song.Recite(bottleCount: 0);

            Assert.Equal(expectedNoBottleLyrics, actualNoBottleLyrics);
        }

        [Fact]
        public void OneBottle()
        {
            string expectedOneBottleLyrics =
@"1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualOneBottleLyrics = Song.Recite(bottleCount: 1);

            Assert.Equal(expectedOneBottleLyrics, actualOneBottleLyrics);
        }

        [Fact]
        public void TwoBottles()
        {
            string expectedTwoBottlesLyrics =
@"2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.

1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualTwoBottlesLyrics = Song.Recite(bottleCount: 2);

            Assert.Equal(expectedTwoBottlesLyrics, actualTwoBottlesLyrics);
        }

        [Fact]
        public void ThreeBottles()
        {
            string expectedThreeBottlesLyrics =
@"3 bottles of milk on the wall, 3 bottles of milk.
Take one down and pass it around, 2 bottles of milk on the wall.

2 bottles of milk on the wall, 2 bottles of milk.
Take one down and pass it around, 1 bottle of milk on the wall.

1 bottle of milk on the wall, 1 bottle of milk.
Take it down and pass it around, no more bottles of milk on the wall.

No more bottles of milk on the wall, no more bottles of milk.
Go to the store and buy some more, 99 bottles of milk on the wall.";

            string actualThreeBottlesLyrics = Song.Recite(bottleCount: 3);

            Assert.Equal(expectedThreeBottlesLyrics, actualThreeBottlesLyrics);
        }

        [Fact]
        public void AllBottles()
        {
            string expected99BottlesLyrics = File.ReadAllText("song.txt");

            string actual99BottlesLyrics = Song.Recite(bottleCount: 99);

            Assert.Equal(expected99BottlesLyrics, actual99BottlesLyrics);
        }
    }
}
