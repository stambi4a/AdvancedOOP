namespace CS_OOP_Advanced_Exam_Prep_July_2016.Contracts
{
    using System.Collections.Generic;

    public interface IShop
    {
        IEnumerable<IProduct> Products { get; }
        IShop AddProduct(IProduct product);
    }
}
