namespace Marketplace.Test.Unit
{  
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Contracts;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Data;
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
        public void TestEditProduct_ValidSize_SizeEditedSuccessfully()
        {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

            IProduct newProduct = this.db.EditProduct(1, 42, "pesho");

            Assert.AreEqual(84, newProduct.Size);
        }

        [TestMethod]
        public void TestEditProduct_ValidName_NameEditedSuccessfully()
        {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

            IProduct newProduct = this.db.EditProduct(1, 69, "gosho");

            Assert.AreEqual("gosho", newProduct.Name);
        }


        [TestMethod]
        public void TestEditProduct_ValidData_ReferencesEquals()
        {
            IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

            IProduct newProduct = this.db.EditProduct(1, 69, "gosho");

            Assert.AreSame(product, newProduct, "References of edited and input product should be the same, and not recreated");
        }

        [TestMethod]
        public void TestEditProduct_ValidData_IdNotChanged()
        {
                IProduct product = this.db.AddProduct(69, "pesho", "BigProduct");

        IProduct newProduct = this.db.EditProduct(1, 69, "gosho");

        Assert.AreEqual(1, newProduct.Id, "Id should be the same and not changed");
        }

        [TestMethod]
        public void TestEditProduct_NonExistentProduct_ShouldReturnNull()
        {
            IProduct newProduct = this.db.EditProduct(1, 69, "gosho");

            Assert.IsNull(newProduct,"The product should not exist");
    }
    }
}
