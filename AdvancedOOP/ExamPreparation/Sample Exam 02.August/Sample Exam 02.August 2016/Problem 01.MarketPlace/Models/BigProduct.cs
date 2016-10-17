namespace Problem_01.MarketPlace.Models
{
    using Enums;

    public class BigProduct : Product
    {
        private const ProductType BigProductType = ProductType.Big;
        public BigProduct(int id, string name, int size)
            : base(id, size, name, BigProductType)
        {
        }
    }
}
