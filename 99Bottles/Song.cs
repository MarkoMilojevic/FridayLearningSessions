using System;
using System.Collections.Generic;
using System.Linq;

namespace _99Bottles
{
    public class Song
    {
        public const int MaxBottleCount = 99;
        private const int SingleVerseLinesCount = 2;

        private string Lyrics { get; }

        private Song(string lyrics) =>
            this.Lyrics = lyrics;

        public static Song CreateOriginal() =>
            new Song(SongLyrics.Original);

        public static Song CreateSixPack() =>
            new Song(SongLyrics.SixPack);

        public string Recite() =>
            this.Verses(startingBottleCount: Song.MaxBottleCount, endingBottleCount: 0);

        public string Verses(int startingBottleCount, int endingBottleCount)
        {
            this.ValidateBottleCount(startingBottleCount);
            this.ValidateBottleCount(endingBottleCount);
            this.ValidateBottlesRange(startingBottleCount, endingBottleCount);

            return this.Verses(startingBottleCount: startingBottleCount)
                .Take((startingBottleCount - endingBottleCount + 1) * 3 - 1)
                .Join(separator: Environment.NewLine);
        }

        public string Verse(int bottleCount)
        {
            this.ValidateBottleCount(bottleCount);

            return this.Verses(startingBottleCount: bottleCount)
                .Take(Song.SingleVerseLinesCount)
                .Join(separator: Environment.NewLine);
        }

        private void ValidateBottleCount(int bottleCount)
        {
            if (bottleCount > Song.MaxBottleCount || bottleCount < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(bottleCount));
        }

        private void ValidateBottlesRange(int startingBottleCount, int endingBottleCount)
        {
            if (endingBottleCount > startingBottleCount)
                throw new ArgumentException(
                    message: $"'{nameof(endingBottleCount)}' cannot be greater than '{nameof(startingBottleCount)}'.",
                    paramName: nameof(endingBottleCount));
        }

        private IEnumerable<string> Verses(int startingBottleCount) =>
            this.Lyrics
                .Split(separator: Environment.NewLine)
                .Skip(count: (Song.MaxBottleCount - startingBottleCount) * 3);
    }
}
