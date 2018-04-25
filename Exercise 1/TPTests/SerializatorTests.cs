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
            string filename = "testWrite.txt";
            Book bookOrig = new Book("A", "B", "C", "D");
            Client clientOrig = new Client("A", "B", "C");
            {
                Serializator ser = new Serializator();
                ser.Add(bookOrig);
                ser.Add(clientOrig);
                ser.SetFilename(filename);
                ser.Write();
            }
            {
                Serializator ser = new Serializator();
                ser.SetFilename(filename);
                ser.Read();
                Book bookNew = (Book)ser.GetNext();
                Client clientNew = (Client)ser.GetNext();

                Assert.AreEqual(bookOrig.ToString(), bookNew.ToString());
                Assert.AreEqual(clientOrig.ToString(), clientNew.ToString());
            }
        }

        [TestMethod()]
        public void ComplexTypesSerializationTest()
        {
            string filename = "complexTestWrite.txt";
            BookCondition bcOrig = new BookCondition(new Book("A", "B", "C", "D"));
            Event eventOrig = new Event(Event.Type.Borrow, bcOrig, new Client("X", "Y", "Z"));
            {
                Serializator ser = new Serializator();
                ser.Add(bcOrig);
                ser.Add(eventOrig);
                ser.SetFilename(filename);
                ser.Write();
            }
            {
                Serializator ser = new Serializator();
                ser.SetFilename(filename);
                ser.Read();
                BookCondition bcNew = (BookCondition)ser.GetNext();
                Event eventNew = (Event)ser.GetNext();
                Assert.AreEqual(bcOrig.ToString(), bcNew.ToString());
                Assert.AreEqual(eventOrig.ToString(), eventNew.ToString());
                Assert.AreSame(bcNew.Book, eventNew.BookCondition.Book);
                Assert.AreSame(bcNew, eventNew.BookCondition);
            }
        }

        [TestMethod()]
        public void DataContextSerializationTest()
        {
            DataContext dcOrig = new DataContext();
            string filename = "dataContextTest.txt";
            {
                Serializator ser = new Serializator();
                ConstantFiller filler = new ConstantFiller();
                filler.Fill(dcOrig);
                ser.Add(dcOrig);
                ser.SetFilename(filename);
                ser.Write();
            }
            {
                Serializator ser = new Serializator();
                ser.SetFilename(filename);
                ser.Read();
                DataContext dcNew = (DataContext)ser.GetNext();
                Assert.AreEqual(dcOrig.bookDictionary[1].ToString(), dcNew.bookDictionary[1].ToString());
                Assert.AreEqual(dcOrig.clientList.Count, dcNew.clientList.Count);
            }
        }
    }
}