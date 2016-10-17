namespace Problem_01.MarketPlace.Models
{
    using Problem_01.MarketPlace.Enums;
    using Problem_01.MarketPlace.Interfaces;

    public abstract class Product : IProduct
    {
        protected Product(int id, int size, string name, ProductType type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Size = size * (int)type / 2;
        }

        public int Id { get; }

        public string Name { get; set; }

        public int Size { get; set; }

        public ProductType Type { get; }

        public override string ToString()
        {
            return $"{this.Type}: {this.Id}. Size: { this.Size }. Name: { this.Name }";
        }
    }
}
