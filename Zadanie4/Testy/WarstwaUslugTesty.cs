using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarstwaUslug;
using WarstwaDanych;
using System.Collections.Generic;
using System.Linq;

namespace Testy
{
    [TestClass]
    public class WasrtwaUslugTesty
    {
        private static DataClassesDataContext db = new DataClassesDataContext();
        [TestMethod]
        public void TestGetProductsByVendorName()
        {
            Random rand = new Random();
            int count = db.Vendors.Count();
            string name = db.Vendors.ToList()[rand.Next(0, count)].Name;

            List<Product> methodResult = Tools.GetProductsByVendorName(name);
            List<Product> foreachResult = new List<Product>();

            foreach (Product p in db.Products)
            {
                foreach (ProductVendor v in db.ProductVendors)
                {
                    if (p.ProductID == v.ProductID && v.Vendor.Name == name)
                    {
                        foreachResult.Add(p);
                    }
                }
            }
            Assert.AreEqual(methodResult.Count, foreachResult.Count);
        }

        [TestMethod]
        public void TestGetProductNamesByVendorName()
        {
            Random rand = new Random();
            int count = db.Vendors.Count();
            string name = db.Vendors.ToList()[rand.Next(0, count)].Name;

            List<string> methodResult = Tools.GetProductNamesByVendorName(name);
            List<string> foreachResult = new List<string>();

            foreach (Product p in db.Products)
            {
                foreach (ProductVendor v in db.ProductVendors)
                {
                    if (p.ProductID == v.ProductID && v.Vendor.Name == name)
                    {
                        foreachResult.Add(p.Name);
                    }
                }
            }
            Assert.AreEqual(methodResult.Count, foreachResult.Count);
        }

        [TestMethod]
        public void GetProductVendorByProductName()
        {
            Random rand = new Random();
            int count = db.Products.Count();

            string name = db.Products.ToList()[rand.Next(0, count)].Name;

            string methodResult = Tools.GetProductVendorByProductName(name);
            List<string> foreachResult = new List<string>();


            foreach (Product p in db.Products)
            {
                foreach (ProductVendor v in db.ProductVendors)
                {
                    if (p.ProductID == v.ProductID && p.Name == name)
                    {
                        foreachResult.Add(v.Vendor.Name);
                    }
                }
            }

            if (methodResult == "" && foreachResult.Count == 0)
            {
                return;
            }

            foreach (string vendor in foreachResult)
            {
                if (vendor == methodResult)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetProductsWithNRecentReviews()
        {
            Random rand = new Random();
            int count = db.ProductReviews.Count();
            int number = rand.Next(0, count);

            List<Product> methodResult = Tools.GetProductsWithNRecentReviews(number);
            List<Product> foreachResult = new List<Product>();

            for (int i = 0; i < number; i++)
            {
                foreachResult.Add(db.ProductReviews.ToList()[i].Product);
            }
            Assert.AreEqual(methodResult.Count, foreachResult.Count);
        }

        [TestMethod]
        public void TestGetNRecentlyReviewedProducts()
        {
            Random rand = new Random();
            int count = db.ProductReviews.Select(p => p.ProductID).Distinct().Count();
            int number = rand.Next(0, count);

            List<Product> methodResult = Tools.GetNRecentlyReviewedProducts(number);
            List<Product> foreachResult = db.ProductReviews.OrderBy(o => o.ModifiedDate).Select(o => o.Product).Distinct().Take(number).ToList();
            Assert.AreEqual(methodResult.Count, foreachResult.Count);
        }

        [TestMethod]
        public void TestGetNProductsFromCategory()
        {
            Random rand = new Random();
            int count = db.ProductCategories.Count();
            string category = db.ProductCategories.ToList()[rand.Next(0, count)].Name;

            List<Product> methodResult = Tools.GetNProductsFromCategory(category, 3);

            foreach (Product p in methodResult)
            {
                Assert.AreEqual(p.ProductSubcategory.ProductCategory.Name, category);
            }
        }

        [TestMethod]
        public void TestGetTotalStandardCostByCategory()
        {
            Random rand = new Random();
            int count = db.ProductCategories.Count();
            ProductCategory category = db.ProductCategories.ToList()[rand.Next(0, count)];

            int methodResult = Tools.GetTotalStandardCostByCategory(category);
            decimal foreachResult = 0;

            foreach (Product p in db.Products)
            {
                if (p.ProductSubcategory != null)
                {
                    if (p.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID)
                    {
                        foreachResult += p.StandardCost;
                    }
                }
            }
            Assert.AreEqual(methodResult, (int)foreachResult);
        }
        [TestMethod]
        public void TestGetWithoutCategory()
        {
            List<Product> methodResult = db.Products.ToList().GetWithoutCategory();
            List<Product> foreachResult = new List<Product>();

            foreach (Product p in db.Products)
            {
                if (p.ProductSubcategory == null || p.ProductSubcategory.ProductCategory == null)
                {
                    foreachResult.Add(p);
                }
            }
            Assert.AreEqual(methodResult.Count, foreachResult.Count);
        }

        [TestMethod]
        public void DivideIntoPages()
        {
            Random rand = new Random();
            int size = rand.Next(1, db.Products.Count());
            List<List<Product>> methodResult = db.Products.ToList().DivideIntoPages(size);

            Assert.AreEqual(methodResult.Count, Math.Ceiling((decimal)db.Products.Count() / (decimal)size));

            for (int i = 0; i < methodResult.Count; i++)
            {
                if (i == methodResult.Count - 1)
                {
                    Assert.IsTrue(methodResult[i].Count <= size);
                }
                else
                {
                    Assert.AreEqual(methodResult[i].Count, size);
                }
            }
        }
    }
}
