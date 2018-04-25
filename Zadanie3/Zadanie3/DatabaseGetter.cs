using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class DatabaseGetter
    {

        static ProductionDataContext dataContext;

        private DatabaseGetter() { }

        public static void Init()
        {
            dataContext = new ProductionDataContext();
        }
        public static List<Product> GetProductsByName(string namePart)
        {
            var products = from product in dataContext.Product
                           where product.Name.Contains(namePart)
                           select product;

            return new List<Product>(products);
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            var products = from p in dataContext.Product
                           join pv in dataContext.ProductVendor on p.ProductID equals pv.ProductID
                           join v in dataContext.Vendor on pv.BusinessEntityID equals v.BusinessEntityID
                           where v.Name == vendorName
                           select p;

            return new List<Product>(products);
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            var names = from p in dataContext.Product
                           join pv in dataContext.ProductVendor on p.ProductID equals pv.ProductID
                           join v in dataContext.Vendor on pv.BusinessEntityID equals v.BusinessEntityID
                           where v.Name == vendorName
                           select p.Name;

            return new List<string>(names);
        }
    }
}
