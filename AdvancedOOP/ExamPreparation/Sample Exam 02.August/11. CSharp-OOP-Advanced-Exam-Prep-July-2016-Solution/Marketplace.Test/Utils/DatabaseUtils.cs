namespace Marketplace.Test.Util
{
    using System.Collections.Generic;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Contracts;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;

    public class DatabaseUtils
    {
        public static IDictionary<string, IShop> CreatePredefinedShops()
        {
            IDictionary<string, IShop> shops = new Dictionary<string, IShop>();
            Mall mall = new Mall();
            Bazaar bazaar = new Bazaar(mall);
            Store store = new Store(bazaar);
            shops.Add(mall.GetType().Name, mall);
            shops.Add(bazaar.GetType().Name, bazaar);
            shops.Add(store.GetType().Name, store);

            return shops;
        }
    }
}
