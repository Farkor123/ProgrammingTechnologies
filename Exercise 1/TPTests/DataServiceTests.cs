using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using TP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        private DataService dataService;

        [TestMethod]
        public void SearchEventsOfClientTest()
        {
            dataService = new DataService(new DataRepository(new DataContext(), new ConstantFiller()));
            dataService.Fill();
            Random rand = new Random();
            Client testClient = dataService.GetClient(rand.Next(10));
            int searchCounter = 0;
            foreach (var _event in dataService.SearchEventsOfClient(testClient))
            {
                Assert.AreEqual(testClient, _event.Client);
                searchCounter++;
            }
            Assert.AreEqual(2, searchCounter);
        }

        [TestMethod]
        public void SearchEventsBetweenTest()
        {
            dataService = new DataService(new DataRepository(new DataContext(), new RandomFiller(5, 5)));
            dataService.Fill();
            Thread.Sleep(10);
            DateTime before = DateTime.Now;
            dataService.CreateEvent(Event.Type.Borrow, dataService.GetBookCondition(0), dataService.GetClient(1));
            dataService.CreateEvent(Event.Type.Return, dataService.GetBookCondition(1), dataService.GetClient(2));
            DateTime after = DateTime.Now;
            Thread.Sleep(10);
            dataService.CreateEvent(Event.Type.Borrow, dataService.GetBookCondition(2), dataService.GetClient(3));

            int searchCounter = 0;
            foreach (var _event in dataService.SearchEventsBetween(before, after))
            {
                Assert.IsTrue(_event.Date <= after);
                Assert.IsTrue(_event.Date >= before);
                searchCounter++;
            }
            Assert.AreEqual(2, searchCounter);
        }

        [TestMethod]
        public void SearchAvailableBooksTest()
        {
            Random rand = new Random();
            dataService = new DataService(new DataRepository(new DataContext(), new RandomFiller(5, 5)));
            dataService.Fill();
            BookCondition randomBC = dataService.GetBookCondition(rand.Next(5));
            dataService.CreateEvent(Event.Type.Borrow, randomBC, dataService.GetClient(rand.Next(5)));
            foreach (var book in dataService.SearchAvailableBooks())
            {
                Assert.AreNotSame(randomBC.Book, book);
            }
        }
    }
}
