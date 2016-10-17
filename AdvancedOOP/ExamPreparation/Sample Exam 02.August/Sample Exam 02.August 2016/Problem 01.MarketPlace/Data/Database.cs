namespace Problem_01.MarketPlace.Data
{
    using System.Collections.Generic;

    using Problem_01.MarketPlace.Enums;
    using Problem_01.MarketPlace.Interfaces;
    public class Database : IDatabase
    {
        public Database()
        {
            this.ProductsByNameAndSizeAndType = new Dictionary<int, IDictionary<string, IDictionary<ProductType, IDictionary<int, IProduct>>>>();
            this.InitializeMarkets();
            this.Products = new Dictionary<int, IProduct>();
        }

        public IDictionary<MarketType, IDictionary<int, IProduct>> ProductsByMarkets { get; private set; }

        public IDictionary<int, IProduct> Products { get; }
        public IDictionary<int, IDictionary<string, IDictionary<ProductType, IDictionary<int, IProduct>>>> ProductsByNameAndSizeAndType
        { get; }

        private void InitializeMarkets()
        {
            this.ProductsByMarkets = new Dictionary<MarketType, IDictionary<int, IProduct>>
                                         {
                                             {
                                                 MarketType.Store,
                                                 new Dictionary
                                                 <int, IProduct>()
                                             },
                                             {
                                                 MarketType.Bazaar,
                                                 new Dictionary
                                                 <int, IProduct>()
                                             },
                                             {
                                                 MarketType.Mall,
                                                 new Dictionary
                                                 <int, IProduct>()
                                             }
                                         };
        }
    }
}
