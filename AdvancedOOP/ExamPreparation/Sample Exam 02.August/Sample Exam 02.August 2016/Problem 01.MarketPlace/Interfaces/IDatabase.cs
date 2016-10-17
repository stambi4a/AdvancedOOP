namespace Problem_01.MarketPlace.Interfaces
{
    using System.Collections.Generic;

    using Problem_01.MarketPlace.Enums;

    public interface IDatabase
    {
        IDictionary<int, IProduct> Products { get; }

        IDictionary<MarketType, IDictionary<int, IProduct>> ProductsByMarkets { get; }
        IDictionary<int, IDictionary<string, IDictionary<ProductType, IDictionary<int, IProduct>>>> ProductsByNameAndSizeAndType
        { get; }
    }
}
