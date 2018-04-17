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
            BookCondition bcOrig = new BookCondition(new Book("A", "B", "C", "D"));
            Event eventOrig = new Event(Event.Type.Borrow, bcOrig, new Client("X", "Y", "Z"));
            ser.Add(bcOrig);
            ser.Add(eventOrig);
            ser.Write();

            ser.Read();
            BookCondition bcNew = (BookCondition)ser.GetNext();
            Event eventNew = (Event)ser.GetNext();
            Assert.AreEqual(bcOrig.ToString(), bcNew.ToString());
            Assert.AreEqual(eventOrig.ToString(), eventNew.ToString());
            Assert.AreSame(bcNew.Book, eventNew.BookCondition.Book);
            Assert.AreSame(bcNew, eventNew.BookCondition);
        }
    }
}