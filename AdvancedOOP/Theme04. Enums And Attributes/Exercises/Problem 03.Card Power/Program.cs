namespace Problem_03.Card_Power
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            var card = new Card(suit, rank);
            Console.WriteLine(card);
        }
    }

    public class Card
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

        public override string ToString()
        {
            return $"Card name: {this.rank} of {this.suit}; Card power: {this.power}";
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
