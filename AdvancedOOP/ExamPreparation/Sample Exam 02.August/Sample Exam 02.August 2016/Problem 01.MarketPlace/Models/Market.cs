namespace Problem_01.MarketPlace.Models
{
    using Interfaces;
    public abstract class Market : IMarket
    {
        protected Market(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; }
    }
}
