namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    using Constants;
    using Contracts;

    public abstract class Product : IProduct
    {
        private int id;
        private string name;
        private int size;
        private IShop shop;

        public Product(int id, int size, string name)
        {
            this.Id = id;
            this.Size = size;
            this.Name = name;
        }

        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; } 
        }

        public IShop Shop
        {
            get { return this.shop; }
            set { this.shop = value; }
        }

        public virtual int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public override string ToString()
        {
            return string.Format(Messages.ProductToString,
                this.GetType().Name,
                this.Id,
                this.Size,
                this.Name);
        }
    }
}
