using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System.Linq;

namespace Zadanie3Test
{
    [TestClass]
    public class ListExtensionsTests
    {
        static ProductionDataContext dataContext;

        [TestInitialize]
        public void TestInit()
        {
            dataContext = new ProductionDataContext();
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(from product in dataContext.Product
                                     select product);
        }

        [TestMethod]
        public void NotCategorizedTest()
        {
            var list = GetProducts();
            list = list.NotCategorized();
            foreach(var p in list)
            {
                Assert.AreEqual(null, p.ProductSubcategoryID);
            }
        }

        [TestMethod]
        public void StringifyTest()
        {
            var list = GetProducts().GetRange(0, 10);

            string result = list.Stringify();
            //Console.Write(result);
            foreach (var p in list)
            {
                Assert.IsTrue(result.Contains(p.Name));
            }
        }
    }
}
