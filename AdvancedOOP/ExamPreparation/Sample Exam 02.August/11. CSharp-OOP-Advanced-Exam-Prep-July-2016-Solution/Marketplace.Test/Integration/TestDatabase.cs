namespace Marketplace.Test.Integration
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Contracts;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Data;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;
    using Util;

    [TestClass]
    public class TestDatabase
    {
        private IDataProvider db;

        [TestInitialize]
        public void SetUp()
        {
            this.db = new DataProvider(DatabaseUtils.CreatePredefinedShops());
        }

        [TestMethod]
        public void TestEditProduct_ValidData_ShouldRemoveFromSizeNameType()
        {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

            this.db.EditProduct(1, 42, "pesho");
            ISet<IProduct> result = new HashSet<IProduct>();

            this.db.GetProductsBySizeNameType(138, "pesho", "BigProduct").ToList().ForEach(x => result.Add(x));
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestEditProduct_ValidData_ShouldBeInNewAssociations()
        {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

            this.db.EditProduct(1, 42, "gosho");

            Assert.IsNotNull(this.db.GetProductsBySizeNameType(84, "gosho", "BigProduct"));
        }

        [TestMethod]
        public void TestEditMovedProduct_ValidData_ShopShouldNotBeChanged()  {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");
            IShop productShop = new Mall();
            product.Shop = productShop;

            IProduct newProduct = this.db.EditProduct(1, 42, "gosho");

            Assert.AreEqual(productShop, newProduct.Shop);
        }
    }
}
