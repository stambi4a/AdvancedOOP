namespace Problem_01.Card_Suit
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Card Suits:");
            foreach (int suit in Enum.GetValues(typeof(Suit)))
            {
                Console.WriteLine($"Ordinal value: {suit}; Name value: {Enum.GetName(typeof(Suit), suit)}");
            }
        }
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
