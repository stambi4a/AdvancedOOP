namespace Problem_01.MarketPlace.Models
{
    using Problem_01.MarketPlace.Enums;

    public class SmallProduct : Product
    {
        private const ProductType SmallProductType = ProductType.Small;
        public SmallProduct(int id, string name, int size)
            : base(id, size, name, SmallProductType)
        {
        }
    }
}
