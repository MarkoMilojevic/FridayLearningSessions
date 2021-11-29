using System.IO;
using Xunit;

namespace _99Bottles.UnitTest;

public class SongLyricsUnitTests
{
    [Fact]
    public void MaxBottleCount() =>
        Assert.Equal(expected: 99, actual: SongLyrics.MaxBottleCount);

    [Fact]
    public void SingleVerseLinesCount() =>
        Assert.Equal(expected: 2, actual: SongLyrics.SingleVerseLinesCount);

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
