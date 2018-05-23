using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarstwaDanych;

namespace WarstwaUslug
{
    public static class Tools
    {
        private static DataClassesDataContext db = new DataClassesDataContext();

        public static List<Product> GetProductsByName(string namePart)
        {
            return (from p in db.Products
                    where p.Name.Contains(namePart)
                    select p).ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            return (from p in db.Products
                    from v in db.ProductVendors
                    where p.ProductID == v.ProductID && v.Vendor.Name == vendorName
                    select p).ToList();
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            return (from p in db.Products
                    from v in db.ProductVendors
                    where p.ProductID == v.ProductID && v.Vendor.Name == vendorName
                    select p.Name).ToList();
        }

        public static string GetProductVendorByProductName(string productName)
        {
            try
            {
                return (from p in db.Products
                        from v in db.ProductVendors
                        where p.ProductID == v.ProductID && p.Name == productName
                        select v.Vendor.Name).First();
            }
            catch
            {
                return "";
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from r in db.ProductReviews
                    orderby r.ModifiedDate
                    select r.Product).Distinct().Take(howManyReviews).ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return (from r in db.ProductReviews
                    orderby r.ModifiedDate
                    select r.Product).Distinct().Take(howManyProducts).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            try
            {
                return (from p in db.Products
                        where p.ProductSubcategory.ProductCategory.Name == categoryName
                        orderby p.Name
                        select p).Take(n).ToList();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            return (int)(from p in db.Products
                         where p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID
                         select p).Sum(o => o.StandardCost);
        }

    }
}
