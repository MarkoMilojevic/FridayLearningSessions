namespace _99Bottles
{
    public class SongLyrics
    {
        public const int MaxBottleCount = 99;

        public const int SingleVerseLinesCount = 2;

        public static readonly SongLyrics Original =
            new SongLyrics(SongLyricsConstants.Original);

        public static readonly SongLyrics SixPack =
            new SongLyrics(SongLyricsConstants.SixPack);

        static SongLyrics() { }

        public string Text { get; }

        private SongLyrics(string text) =>
            this.Text = text;
    }
}
