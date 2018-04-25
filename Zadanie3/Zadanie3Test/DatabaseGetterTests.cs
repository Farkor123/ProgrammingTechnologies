using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class DatabaseGetterTests
    {
        [TestInitialize]
        public void TestInit()
        {
            DatabaseGetter.Init();
        }

        [TestMethod]
        public void GetProductsByNameTest()
        {
            const string namePart = "ar";
            var queryResult = DatabaseGetter.GetProductsByName(namePart);
            Assert.AreEqual(28, queryResult.Count);
            foreach(var r in queryResult)
            {
                Assert.IsTrue(r.Name.Contains(namePart));
            }
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            const string vendorName = "Trikes, Inc.";
            var queryResult = DatabaseGetter.GetProductsByVendorName(vendorName);
            Assert.AreEqual(2, queryResult.Count);
            Assert.AreEqual("Mountain Tire Tube", queryResult[0].Name);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            const string vendorName = "Trikes, Inc.";
            var queryResult = DatabaseGetter.GetProductNamesByVendorName(vendorName);
            Assert.AreEqual(2, queryResult.Count);
            Assert.AreEqual("Mountain Tire Tube", queryResult[0]);
        }
    }
}
