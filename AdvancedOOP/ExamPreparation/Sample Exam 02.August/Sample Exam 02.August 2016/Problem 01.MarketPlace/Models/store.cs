namespace Problem_01.MarketPlace.Models
{
    public class Store : Market
    {
        private const int StoreCapacity = 15;

        public Store()
            : base(StoreCapacity)
        {
        }
    }
}
