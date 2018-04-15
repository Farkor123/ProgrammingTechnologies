using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Tests
{
    [TestClass()]
    public class SerializatorTests
    {
        [TestMethod()]
        public void DeserTest()
        {
            Serializator s = new Serializator();
            Book b = new Book("A", "B", "C", "D");
            s.Add(b, true);
            s.Read();
            Book c = (Book)s.GetNext();
            Assert.AreEqual(b.ToString(), c.ToString());
        }

        [TestMethod()]
        public void PrintTest()
        {
            Serializator s = new Serializator();
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());
            dataRepository.UseFiller();
            s.Print();
        }
    }
}