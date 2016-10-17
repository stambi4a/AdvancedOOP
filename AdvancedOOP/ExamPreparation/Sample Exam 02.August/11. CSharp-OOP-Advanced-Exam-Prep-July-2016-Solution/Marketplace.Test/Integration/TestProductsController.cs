namespace Marketplace.Test.Integration
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using CS_OOP_Advanced_Exam_Prep_July_2016;
    using Constants = CS_OOP_Advanced_Exam_Prep_July_2016.Constants;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Contracts;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Controllers;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;

    [TestClass]
    public class TestProductsController
    {
        private ProductsController controller;
        private IDataProvider db;
        Mock<IDataProvider> mock;

        [TestInitialize]
        public void SetUp()
        {
            MarketApplication application = new MarketApplication();
            mock = new Mock<IDataProvider>();
            this.controller = application.Dispatcher.Locate<ProductsController>(); 
        }

        [TestMethod]
        public void TestEdit_NonExistentProduct_MessageNoExists()
        {
            mock.Setup(db => db.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns<IProduct>(null);
            this.controller.Database = mock.Object;
            string result = this.controller.EditProduct(1, "sdfdfg", 23);

            Assert.AreEqual(
                    string.Format(Constants.Messages.ProductDoesNotExist, 1),
                    result
            );
        }

        [TestMethod]
        public void TestEdit_PredefinedProduct_MessageEditedSuccessfull()
        {
            IProduct expected = new BigProduct(4, 69, "pesho");

            mock.Setup(db => db.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(expected);
            this.controller.Database = mock.Object;
            string result = this.controller.EditProduct(4, "sdfdfg", 23);

            Assert.AreEqual(
                    string.Format(Constants.Messages.ProductEditedOk, 4),
                    result
            );
        }
    }
}

