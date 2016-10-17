namespace Problem_01.MarketPlace.Interfaces
{
    using Problem_01.MarketPlace.Enums;

    public interface IProduct
    {
        int Id { get; }
        string Name { get; set; }

        int Size { get; set; }
        ProductType Type { get; }
    }
}
