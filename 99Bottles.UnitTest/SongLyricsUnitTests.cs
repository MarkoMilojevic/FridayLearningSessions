using System.IO;
using Xunit;

namespace _99Bottles.UnitTest
{
    public class SongLyricsUnitTests
    {
        [Fact]
        public void Original()
        {
            string expected99BottlesLyrics = File.ReadAllText("song-original.txt");

            Assert.Equal(expected99BottlesLyrics, SongLyrics.Original.Text);
        }

        [Fact]
        public void SixPack()
        {
            string expected99BottlesLyrics = File.ReadAllText("song-sixpack.txt");

            Assert.Equal(expected99BottlesLyrics, SongLyrics.SixPack.Text);
        }
    }
}
