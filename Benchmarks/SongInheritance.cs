using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class SongInheritance
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

    public string Verse(int number)
    {
        BottleNumber bottleNumber = BottleNumber.Create(number);

        return
            $"{bottleNumber} of milk on the wall, "
            + $"{bottleNumber} of milk.{Environment.NewLine}"
            + $"{bottleNumber.Action}"
            + $"{bottleNumber.Successor()} of milk on the wall.{Environment.NewLine}";
    }

    public class BottleNumber
    {
        private readonly int number;

        protected BottleNumber(int number) =>
            this.number = number;

        public static BottleNumber Create(int number) =>
            number switch
            {
                0 => new Bottle0(),
                1 => new Bottle1(),
                _ => new BottleNumber(number)
            };

        public virtual string Quantity => this.number.ToString();

        public virtual string Container => "bottles";

        public virtual string Action => $"Take {this.Pronoun} down and pass it around, ";

        public virtual string Pronoun => "one";

        public virtual BottleNumber Successor() => BottleNumber.Create(this.number - 1);

        public override string ToString() => $"{this.Quantity} {this.Container}";
    }

    public class Bottle0 : BottleNumber
    {
        public Bottle0() : base(0) { }

        public override string Quantity => "no more";

        public override string Action => "Go to the store and buy some more, ";

        public override BottleNumber Successor() => BottleNumber.Create(int.MaxValue);
    }

    public class Bottle1 : BottleNumber
    {
        public Bottle1() : base(1) { }

        public override string Container => "bottle";

        public override string Pronoun => "it";
    }
}
