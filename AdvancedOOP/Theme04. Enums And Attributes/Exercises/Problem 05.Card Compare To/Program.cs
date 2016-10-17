namespace Problem_05.Card_Compare_To
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            var firstCard = new Card(suit, rank);

            rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            var secondCard = new Card(suit, rank);

            var higherCard = firstCard.CompareTo(secondCard) > 0 ? firstCard : secondCard;
            Console.WriteLine(higherCard);
        }
    }

    public class Card : IComparable<Card>
    {
        private Rank rank;

        private Suit suit;

        private int power;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            this.CalculatePower();
        }

        private void CalculatePower()
        {
            this.power = (int)(this.suit) + (int)(this.rank);
        }

        public int CompareTo(Card other)
        {
            return this.power.CompareTo(other.power);
        }

        public override string ToString()
        {
            return $"{this.rank} of {this.suit}{this.power}";
        }
    }

    public enum Rank
    {
        Ace = 14,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}
