namespace Problem_02.Card_Rank
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Card Ranks:");
            foreach (int suit in Enum.GetValues(typeof(Rank)))
            {
                Console.WriteLine($"Ordinal value: {suit}; Name value: {Enum.GetName(typeof(Rank), suit)}");
            }
        }
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}
