namespace Problem_01.MarketPlace.Models
{
    public class Mall : Market
    {
        private const int MallCapacity = int.MaxValue;

        public Mall()
                : base(MallCapacity)
            {
        }
    }
}
