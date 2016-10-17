namespace Problem_08.Card_Game
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main(string[] args)
        {
            var firstPlayerName = Console.ReadLine();
            var firstPlayer = new Player(firstPlayerName);

            var secondPlayerName = Console.ReadLine();
            var secondPlayer = new Player(secondPlayerName);
            var game = new Game(firstPlayer, secondPlayer);
            game.DealCards();
            game.FixWinner();
        }
    }

    public class Game
    {
        private const int NumberOfCardsForEachPlayer = 5;
        public Game(Player first, Player second)
        {
            this.FirstPlayer = first;
            this.SecondPlayer = second;
            this.GenerateCardDeck();
        }

        public Player FirstPlayer { get; }

        public Player SecondPlayer { get; }

        public HashSet<Card> CardDeck { get; private set; }

        private void GenerateCardDeck()
        {
            this.CardDeck = new HashSet<Card>(new CardEqualityComparer());
            var suits = Enum.GetValues(typeof(Suit));
            var ranks = Enum.GetValues(typeof(Rank));
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card((Suit)suit, (Rank)rank);
                    this.CardDeck.Add(card);
                }
            }
        }

        public void FixWinner()
        {
            var winner = this.FirstPlayer.CompareTo(this.SecondPlayer) > 0 ? this.FirstPlayer : this.SecondPlayer;
            Console.WriteLine(winner);
        }

        public void DealCards()
        {
            this.DealPlayer(this.FirstPlayer);
            this.DealPlayer(this.SecondPlayer);
        }

        private void DealPlayer(Player player)
        {
            var index = 0;
            while (index < NumberOfCardsForEachPlayer)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    var rank = (Rank)Enum.Parse(typeof(Rank), input[0]);
                    var suit = (Suit)Enum.Parse(typeof(Suit), input[2]);
                    var card = new Card(suit, rank);
                    if (!this.CardDeck.Remove(card))
                    {
                        throw new InvalidOperationException("Card is not in the deck.");
                    }

                    player.AddCard(card);
                    index++;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }

    public class CardEqualityComparer : IEqualityComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            var result = x.Suit == y.Suit && x.Rank == y.Rank ? 0 : 1;

            return result;
        }

        public bool Equals(Card x, Card y)
        {
            var result = x.Suit == y.Suit && x.Rank == y.Rank;

            return result;
        }

        public int GetHashCode(Card obj)
        {
            return obj.Power;
        }
    }

    public class Player : IComparable<Player>
    {
        private SortedSet<Card> cards;

        public Player(string name)
        {
            this.cards = new SortedSet<Card>();
            this.Name = name;
        }

        public string Name { get; }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public int CompareTo(Player other)
        {
            return this.cards.Max.CompareTo(other.cards.Max);
        }

        public override string ToString()
        {
            return $"{this.Name} wins with {this.cards.Max}.";
        }
    }

    public class Card : IComparable<Card>
    {
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.CalculatePower();
        }

        public Suit Suit { get; }

        public Rank Rank { get; }

        public int Power { get; private set; }

        private void CalculatePower()
        {
            this.Power = (int)(this.Suit) + (int)(this.Rank);
        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
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
