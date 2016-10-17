namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Contracts;
    using Lifecycle;
    using Lifecycle.Component;
    using Lifecycle.Controller;
    using Lifecycle.Request;

    [Component]
    [Controller]
    public class ProductsController
    {
        [Inject]
        private IDataProvider db;

        public IDataProvider Database
        {
            get { return this.db; }
            set { this.db = value; }
        }

        [RequestMapping(value: "/product/{size}/{name}/{type}", method: RequestMethod.ADD)]
        public string AddProduct([UriParameter("size")] int size, [UriParameter("name")] string name, [UriParameter("type")] string type)
        {
            IProduct addedProduct = db.AddProduct(size, name, type);

            return string.Format(Messages.ProductRegisteredOK, addedProduct.Id);
        }

        [RequestMapping(value: "/product/{size}/{name}/{type}", method: RequestMethod.GET)]
        public string GetProductBySizeNameType([UriParameter("size")] int size, [UriParameter("name")] string name, [UriParameter("type")] string type)
        {
            IEnumerable<IProduct> result = db.GetProductsBySizeNameType(size, name, type);
            return this.GetProductsResult(result);

        }

        [RequestMapping(value: "/product/{size}/{name}", method: RequestMethod.GET)]
        public string GetProductBySizeName([UriParameter("size")] int size, [UriParameter("name")] string name)
        {
            IEnumerable<IProduct> result = db.GetProductsBySizeName(size, name);
            return this.GetProductsResult(result);
        }

        [RequestMapping(value: "/product/{id}", method: RequestMethod.GET)]
        public string GetProductById([UriParameter("id")] int id)
        {
            IProduct product = db.GetProductById(id);
            if(product == null)
            {
                return string.Format(Messages.ProductDoesNotExist, id);
            }

            return product.ToString();
        }

        [RequestMapping(value: "/product/{id}/{newName}/{newSize}", method: RequestMethod.EDIT)]
        public string EditProduct([UriParameter("id")] int id, [UriParameter("newName")] string newName, [UriParameter("newSize")] int newSize)
        {
            IProduct product = db.EditProduct(id, newSize, newName);
            if(product == null)
            {
                return string.Format(Messages.ProductDoesNotExist, id);
            }

            return string.Format(Messages.ProductEditedOk, id);
        }

        private string GetProductsResult(IEnumerable<IProduct> result)
        {
            if (result == null)
            {
                return Messages.ProductCriteriaNo;
            }

            StringBuilder sb = new StringBuilder();
            result.ToList().ForEach(p => sb.AppendLine(p.ToString()));

            return sb.ToString().Trim();
        }
    }
}
