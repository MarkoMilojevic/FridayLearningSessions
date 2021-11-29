using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class SongComposition
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
        private readonly string quantity;
        private readonly string container;
        private readonly int successor;

        public string Action { get; }

        public static BottleNumber Create(int ordinal)
        {
            string container =
                ordinal == 1
                    ? "bottle"
                    : "bottles";

            string action =
                ordinal == 0
                    ? "Go to the store and buy some more, "
                : ordinal == 1
                    ? "Take it down and pass it around, "
                : "Take one down and pass it around, ";

            int successor =
                ordinal == 0
                    ? 1_000_000
                    : ordinal - 1;

            return new BottleNumber(
                quantity: $"{ordinal}",
                container: container,
                action: action,
                successor: successor
            );
        }

        private BottleNumber(
            string quantity,
            string container,
            string action,
            int successor)
        {
            this.quantity = quantity;
            this.container = container;
            this.successor = successor;

            this.Action = action;
        }

        public BottleNumber Successor() =>
            BottleNumber.Create(this.successor);

        public override string ToString() =>
            $"{this.quantity} {this.container}";
    }
}
