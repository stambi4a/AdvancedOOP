namespace CS_OOP_Advanced_Exam_Prep_July_2016.Data
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Constants;
    using Contracts;
    using Models.Shops;
    using Lifecycle.Component;

    [Component]
    public class DataProvider : IDataProvider
    {
        private IDictionary<int, IProduct> productsById;
        private IDictionary<int, IDictionary<string, ISet<IProduct>>> productsBySizeName;
        private IDictionary<int, IDictionary<string, IDictionary<Type, ISet<IProduct>>>> productsBySizeNameType;

        private IDictionary<string, IShop> shops;

        [Inject]
        private ITypeProvider provider;
        private IDictionary<string, IShop> dictionary;

        public DataProvider()
        {
            InitializeProductStructures();
            this.shops = new Dictionary<string, IShop>();
            this.InitializeShops();
        }

        public DataProvider(IDictionary<string, IShop> dictionary)
        {
            InitializeProductStructures();
            this.dictionary = dictionary;
        }

        public IProduct AddProduct(int size, string name, string type)
        {
            int id = this.productsById.Count + 1;
            Type productType = this.GetType(type);

            object[] parameters = new object[]
            {
                id,
                size,
                name
            };

            IProduct product = (IProduct)Activator.CreateInstance(productType, parameters);
            productsById.Add(id, product);
            this.AddToNestedStructures(product);

            return product;
        }

        public IShop AddProductToShop(string shopType, int productId)
        {
            IProduct product = this.GetProductById(productId);
            if (product == null)
            {
                return null;
            }

            IShop shop = this.shops[shopType];
            if(product.Shop != null)
            {
                throw new InvalidOperationException(string.Format(Messages.ProductBelongsToShop, productId, product.Shop.GetType().Name));
            }

            product.Shop = shop;

            return shop.AddProduct(product);
        }

        public IProduct EditProduct(int id, int newSize, string newName)
        {
            IProduct product = this.GetProductById(id);
            if(product == null)
            {
                return null;
            }

            this.RemoveOldData(product);

            product.Size = newSize;
            product.Name = newName;

            this.AddToNestedStructures(product);

            return product;
        }

        public IProduct GetProductById(int id)
        {
            return this.productsById
                .Where(p => p.Key == id)
                .FirstOrDefault()
                .Value;
        }

        public IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type)
        {
            try
            {
                Type productType = this.GetType(type);
                return this.productsBySizeNameType[size][name][productType];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public IEnumerable<IProduct> GetProductsBySizeName(int size, string name)
        {
            try
            {
                return this.productsBySizeName[size][name];
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

        public IEnumerable<IProduct> GetProductsFromShop(string shopType)
        {
            IShop shop = this.shops[shopType];

            return shop.Products;
        }

        private void InitializeShops()
        {
            Mall mall = new Mall();
            Bazaar bazaar = new Bazaar(mall);
            Store store = new Store(bazaar);

            shops.Add("Mall", mall);
            shops.Add("Bazaar", bazaar);
            shops.Add("Store", store);
        }

        private Type GetType(string type)
        {
            Type result = Assembly.GetExecutingAssembly()
               .GetTypes()
               .Where(x => x.Name == type)
               .FirstOrDefault();

            return result;
        }

        private void AddToNestedStructures(IProduct product)
        {
            int size = product.Size;
            string name = product.Name;
            Type type = product.GetType();

            if(!productsBySizeName.ContainsKey(size))
            {
                productsBySizeName.Add(size, new Dictionary<string, ISet<IProduct>>());
            }

            if(!productsBySizeName[size].ContainsKey(name))
            {
                productsBySizeName[size].Add(name, new HashSet<IProduct>());
            }

            productsBySizeName[size][name].Add(product);

            if(!productsBySizeNameType.ContainsKey(size))
            {
                productsBySizeNameType.Add(size, new Dictionary<string, IDictionary<Type, ISet<IProduct>>>());
            }

            if(!productsBySizeNameType[size].ContainsKey(name))
            {
                productsBySizeNameType[size].Add(name, new Dictionary<Type, ISet<IProduct>>());
            }

            if(!productsBySizeNameType[size][name].ContainsKey(type))
            {
                productsBySizeNameType[size][name].Add(type, new HashSet<IProduct>());
            }

            productsBySizeNameType[size][name][type].Add(product);
        }

        private void RemoveOldData(IProduct product)
        {
            this.productsBySizeName[product.Size][product.Name].Remove(product);
            this.productsBySizeNameType[product.Size][product.Name][product.GetType()].Remove(product);
        }

        private void InitializeProductStructures()
        {
            this.productsById = new Dictionary<int, IProduct>();
            this.productsBySizeName = new Dictionary<int, IDictionary<string, ISet<IProduct>>>();
            this.productsBySizeNameType = new Dictionary<int, IDictionary<string, IDictionary<Type, ISet<IProduct>>>>();
        }
    }
}
