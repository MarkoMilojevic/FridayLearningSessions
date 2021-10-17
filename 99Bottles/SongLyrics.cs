namespace _99Bottles
{
    public class SongLyrics
    {
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
