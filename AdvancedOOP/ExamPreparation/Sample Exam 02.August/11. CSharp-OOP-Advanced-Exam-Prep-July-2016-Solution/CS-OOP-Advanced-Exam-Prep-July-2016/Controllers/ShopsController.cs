namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Contracts;
    using Lifecycle;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using Lifecycle.Component;

    [Component]
    [Controller]
    public class ShopsController
    {
        [Inject]
        private IDataProvider db;

        [RequestMapping(value: "/shop/{type}/{productId}", method: RequestMethod.ADD)]
        public string AddProductToShop([UriParameter("type")] string type, [UriParameter("productId")] int productId)
        {
            try
            {
                IShop shop = this.db.AddProductToShop(type, productId);
                if(shop == null)
                {
                    return string.Format(Messages.ProductDoesNotExist, productId);
                }

                return string.Format(Messages.ProductMovedOk, productId, shop.GetType().Name);
            }
            catch(InvalidOperationException ioe)
            {
                return ioe.Message;
            }
        }

        [RequestMapping(value: "/shop/{type}", method: RequestMethod.GET)]
        public string GetProductsFromShop([UriParameter("type")] string type)
        {
            IEnumerable<IProduct> products = this.db.GetProductsFromShop(type);

            StringBuilder sb = new StringBuilder();
            products.ToList().ForEach(p => sb.AppendLine(p.ToString()));

            string result = sb.ToString().Trim();

            if(string.IsNullOrEmpty(result))
            {
                return Messages.ProductCriteriaNo;
            }

            return result;
        }
    }
}
