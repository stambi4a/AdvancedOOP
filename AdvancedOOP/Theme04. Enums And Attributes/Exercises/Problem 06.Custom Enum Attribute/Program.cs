namespace Problem_06.Custom_Enum_Attribute
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Program
    {
        private static void Main(string[] args)
        {
            var category = Console.ReadLine();
            var attribute =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .ToList()
                    .SelectMany(type => type.GetCustomAttributes(typeof(TypeAttribute)))
                    .FirstOrDefault(attr => ((TypeAttribute)attr).Category == category) as TypeAttribute;
           Console.WriteLine($"Type = {attribute.Type}, Description = {attribute.Description}");
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
            return $"Card name: {this.rank} of {this.suit}; Card power: {this.power}";
        }
    }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
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

    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }


    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; set; }

        public  string Category { get; set; }

        public  string Description { get; set; }
    }
}
