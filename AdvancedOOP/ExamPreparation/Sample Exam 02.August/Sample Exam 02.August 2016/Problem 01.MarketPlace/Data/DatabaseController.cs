namespace Problem_01.MarketPlace.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Interfaces;

    using Problem_01.MarketPlace.Lifecycle;
    using Problem_01.MarketPlace.Lifecycle.Controller;
    using Problem_01.MarketPlace.Lifecycle.Request;

    [Controller]
    public class DatabaseController : IController
    {
        private readonly IDatabase database;

        public DatabaseController(IDatabase database)
        {
            this.database = database;
            this.CurrentProductId = 0;
        }

        public int CurrentProductId { get; private set; }

        [RequestMapping("/product/{size}/{name}/{type}", RequestMethod.ADD)]
        public string Add(int size, string name, ProductType type)
        {
            var productType = Type.GetType("Problem_01.MarketPlace.Models." + type + "Product");
            var product = (IProduct)Activator.CreateInstance(productType, new object[] {this.CurrentProductId, size, name });
            this.database.Products.Add(this.CurrentProductId++, product);
            if (!this.database.ProductsByNameAndSizeAndType.ContainsKey(size))
            {
                this.database.ProductsByNameAndSizeAndType.Add(size, new Dictionary<string, IDictionary<ProductType, IDictionary<int, IProduct>>>());
            }

            if (!this.database.ProductsByNameAndSizeAndType[size].ContainsKey(name))
            {
                this.database.ProductsByNameAndSizeAndType[size].Add(name, new Dictionary<ProductType, IDictionary<int, IProduct>>());
            }

            if (!this.database.ProductsByNameAndSizeAndType[size][name].ContainsKey(type))
            {
                this.database.ProductsByNameAndSizeAndType[size][name].Add(type, new Dictionary<int, IProduct>());
            }

            this.database.ProductsByNameAndSizeAndType[size][name][type].Add(this.CurrentProductId, product);

            return $"Product {this.CurrentProductId - 1} registered successfully";
        }

        [RequestMapping("/shop/{type}/{productId}", RequestMethod.ADD)]
        public string Add(MarketType type, int id)
        {
            if (!this.database.Products.ContainsKey(id))
            {
                throw new ArgumentException($"Product {id} does not exist");
            }

            if (this.database.ProductsByMarkets[type].ContainsKey(id))
            {
                throw new ArgumentException($"Product {id} is already registered to a market {type}");
            }

            var product = this.database.Products[id];
            while (this.database.ProductsByMarkets[type].Values.Sum(prod => prod.Size) + product.Size > (int)type)
            {
                type = Enum.GetValues(typeof(MarketType)).Cast<MarketType>().First(value => (int)value > (int)type);
            }

            this.database.ProductsByMarkets[type].Add(id, product);

            return $"Product {id} moved to market {type}";
        }

        [RequestMapping("/product/{id}/{newName}/{newSize}", RequestMethod.EDIT)]
        public string Edit(int id, string newName, int newSize)
        {
            if (!this.database.Products.ContainsKey(id))
            {
                throw new ArgumentException($"Product {id} does not exist");
            }

            var product = this.database.Products[id];
            this.database.ProductsByNameAndSizeAndType[product.Size][product.Name][product.Type].Remove(product.Id);
            product.Name = newName;
            product.Size = newSize;
            if (!this.database.ProductsByNameAndSizeAndType.ContainsKey(newSize))
            {
                this.database.ProductsByNameAndSizeAndType.Add(newSize, new Dictionary<string, IDictionary<ProductType, IDictionary<int, IProduct>>>());
            }

            if (!this.database.ProductsByNameAndSizeAndType[newSize].ContainsKey(newName))
            {
                this.database.ProductsByNameAndSizeAndType[newSize].Add(newName, new Dictionary<ProductType, IDictionary<int, IProduct>>());
            }

            if (!this.database.ProductsByNameAndSizeAndType[newSize][newName].ContainsKey(product.Type))
            {
                this.database.ProductsByNameAndSizeAndType[newSize][newName].Add(product.Type, new Dictionary<int, IProduct>());
            }

            this.database.ProductsByNameAndSizeAndType[newSize][newName][product.Type].Add(product.Id, product);
            return $"Product {id} successfully edited";
        }

        [RequestMapping("/product/{size}/{name}", RequestMethod.GET)]
        public string Get(int size, string name)
        {
            if (this.database.ProductsByNameAndSizeAndType.ContainsKey(size)
                || this.database.ProductsByNameAndSizeAndType[size].ContainsKey(name))
            {
                throw new ArgumentException("No products by the given criteria");
            }

            var products = this.database.ProductsByNameAndSizeAndType[size][name].SelectMany(product=>product.Value.Values);
            return string.Join(Environment.NewLine, products);
        }

        [RequestMapping("/product/{size}/{name}/{type}", RequestMethod.GET)]
        public string Get(int size, string name, ProductType type)
        {
            if (!this.database.ProductsByNameAndSizeAndType.ContainsKey(size)
                || !this.database.ProductsByNameAndSizeAndType[size].ContainsKey(name) ||
                !this.database.ProductsByNameAndSizeAndType[size][name].ContainsKey(type))
            {
                throw new ArgumentException("No products by the given criteria");
            }

            var products = this.database.ProductsByNameAndSizeAndType[size][name][type].Values;
            return string.Join(Environment.NewLine, products);
        }

        [RequestMapping("/product/{id}", RequestMethod.GET)]
        public string Get(int id)
        {
            if (!this.database.Products.ContainsKey(id))
            {
                throw new ArgumentException($"Product {id} does not exist");
            }

            var product = this.database.Products[id];

            return product.ToString();
        }

        [RequestMapping("/product/{type}", RequestMethod.GET)]
        public string Get(MarketType type)
        {
            if(!this.database.ProductsByMarkets.ContainsKey(type))
            {
                throw new ArgumentException("No products by the given criteria");
            }

            var products = this.database.ProductsByMarkets[type].Values;
            return string.Join(Environment.NewLine, products);
        }
    }
}
