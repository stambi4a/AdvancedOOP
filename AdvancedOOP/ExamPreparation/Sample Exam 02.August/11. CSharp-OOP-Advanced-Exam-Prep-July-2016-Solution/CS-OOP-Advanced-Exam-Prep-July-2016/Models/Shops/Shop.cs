namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Shop<T> : IShop where T : IShop
    {
        private IList<IProduct> products;

        protected T successor;
        protected long filledCapacity;
        protected long capacity;

        public Shop(T successor, long capacity)
        {
            this.successor = successor;
            this.capacity = capacity;
            this.products = new List<IProduct>();
        }

        public IEnumerable<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }

        public virtual IShop AddProduct(IProduct product)
        {
            if(product.Size + this.filledCapacity > this.capacity && this.successor != null)
            {
                return this.successor.AddProduct(product);
            }

            this.products.Add(product);
            this.filledCapacity += product.Size;

            return this;
        }
    }
}
