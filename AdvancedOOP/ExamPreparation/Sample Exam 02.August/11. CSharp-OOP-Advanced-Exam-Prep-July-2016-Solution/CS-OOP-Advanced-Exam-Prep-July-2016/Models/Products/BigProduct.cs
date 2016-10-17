namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    public class BigProduct : Product
    {
        private const int SizeModifier = 2;

        public BigProduct(int id, int size, string name)
            : base(id, size, name)
        {
        }

        public override int Size
        {
            get { return base.Size; }
            set { base.Size = value * SizeModifier; }
        }
    }
}
