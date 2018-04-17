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
        public void SimpleTypesSerializationTest()
        {
            Serializator ser = new Serializator();
            Book bookOrig = new Book("A", "B", "C", "D");
            Client clientOrig = new Client("A", "B", "C");
            ser.Add(bookOrig);
            ser.Add(clientOrig);
            ser.Write();

            ser.Read();
            Book bookNew = (Book)ser.GetNext();
            Client clientNew = (Client)ser.GetNext();

            Assert.AreEqual(bookOrig.ToString(), bookNew.ToString());
            Assert.AreEqual(clientOrig.ToString(), clientNew.ToString());
        }

        [TestMethod()]
        public void ComplexTypesSerializationTest()
        {
            Serializator ser = new Serializator();
            Book bookOrig = new Book("A", "B", "C", "D");
            ser.Add(bookOrig);
            ser.Read();
            Book bookNew = (Book)ser.GetNext();
            Assert.AreEqual(bookOrig.ToString(), bookNew.ToString());

            ser = new Serializator();
            Client clientOrig = new Client("A", "B", "C");
            ser.Add(clientOrig);
            ser.Read();
            Client clientNew = (Client)ser.GetNext();
            Assert.AreEqual(clientOrig.ToString(), clientNew.ToString());
        }
    }
}