using System;
using System.Collections.Generic;
using System.Linq;

namespace _99Bottles
{
    public class Song
    {
        public const int MaxBottleCount = 99;
        private const int SingleVerseLinesCount = 2;

        private SongLyrics SongLyrics { get; }

        public Song(SongLyrics songLyrics) =>
            this.SongLyrics = songLyrics ?? throw new ArgumentNullException(nameof(songLyrics));

        public string Recite() =>
            this.Verses(startingBottleCount: Song.MaxBottleCount, endingBottleCount: 0);

        public string Verses(int startingBottleCount, int endingBottleCount)
        {
            Song.ValidateBottleCounts(startingBottleCount, endingBottleCount);

            return this.Verses(startingBottleCount: startingBottleCount)
                .Take((startingBottleCount - endingBottleCount + 1) * 3 - 1)
                .Join(separator: Environment.NewLine);
        }

        public string Verse(int bottleCount)
        {
            Song.ValidateBottleCount(bottleCount);

            return this.Verses(startingBottleCount: bottleCount)
                .Take(Song.SingleVerseLinesCount)
                .Join(separator: Environment.NewLine);
        }

        private IEnumerable<string> Verses(int startingBottleCount) =>
            this.SongLyrics
                .Text
                .Split(separator: Environment.NewLine)
                .Skip(count: (Song.MaxBottleCount - startingBottleCount) * 3);

        private static void ValidateBottleCount(int bottleCount)
        {
            if (bottleCount > Song.MaxBottleCount || bottleCount < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(bottleCount));
        }

        private static void ValidateBottleCounts(int startingBottleCount, int endingBottleCount)
        {
            Song.ValidateBottleCount(startingBottleCount);
            Song.ValidateBottleCount(endingBottleCount);

            if (endingBottleCount > startingBottleCount)
                throw new ArgumentException(
                    message: $"'{nameof(endingBottleCount)}' cannot be greater than '{nameof(startingBottleCount)}'.",
                    paramName: nameof(endingBottleCount));
        }
    }
}
