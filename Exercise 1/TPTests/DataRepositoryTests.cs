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
    public class DataRepositoryTests
    {
        DataRepository dataRepository;

        #region TestsHelpers
        private List<Book> MakeBookList()
        {
            Random rand = new Random();
            List<Book> list = new List<Book>();
            list.Add(new Book("Test Author 1", rand.Next(1000, 10000).ToString(), "Test Title 1", "2019"));
            list.Add(new Book("Test Author 2", rand.Next(1000, 10000).ToString(), "Test Title 2", "2020"));
            return list;
        }
        private List<BookCondition> MakeBookConditionList()
        {
            Random rand = new Random();
            List<BookCondition> list = new List<BookCondition>();
            foreach (var book in MakeBookList())
            {
                list.Add(new BookCondition(book));
            }
            return list;
        }
        private List<Client> MakeClientList()
        {
            Random rand = new Random();
            List<Client> list = new List<Client>();
            list.Add(new Client("Test", "McTest", "0"));
            list.Add(new Client("Test", "Testowsky", "1"));
            return list;
        }
        private List<Event> MakeEventList()
        {
            List<Event> list = new List<Event>();
            list.Add(new Event(Event.Type.Borrow, new BookCondition(new Book("x", "0", "y", "1")), new Client("A", "B", "0")));
            list.Add(new Event(Event.Type.Return, new BookCondition(new Book("z", "1", "w", "2")), new Client("D", "C", "1")));
            return list;
        }
        #endregion TestHelpers

        [TestInitialize]
        public void Initialize()
        {
            dataRepository = new DataRepository(new DataContext(), new ConstantFiller());
        }

        #region BookTests
        [TestMethod()]
        public void AddBookTest()
        {
            Book testBook = new Book("Test Author", "1234567890", "Test Title", "2019");
            dataRepository.AddBook(testBook);
            Assert.AreEqual(testBook, dataRepository.GetBook(0));
        }

        [TestMethod()]
        public void GetAllBooksTest()
        {
            List<Book> testList = MakeBookList();
            foreach (var book in testList)
            {
                dataRepository.AddBook(book);
            }

            IEnumerable<Book> result = dataRepository.GetAllBooks();
            int i = 0;
            foreach (var book in result)
            {
                Assert.AreEqual(testList[i], book);
                i++;
            }
        }

        [TestMethod()]
        public void GetBooksAmountTest()
        {
            List<Book> testList = MakeBookList();
            foreach (var book in testList)
            {
                dataRepository.AddBook(book);
            }

            Assert.AreEqual(2, dataRepository.GetBooksAmount());
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            List<Book> testList = MakeBookList();
            foreach (var book in testList)
            {
                dataRepository.AddBook(book);
            }
            Book testBook = new Book("Test 3", "1234567890", "Test 3", "1999");
            int bookNumber = testList.Count() - 1;
            dataRepository.UpdateBook(bookNumber, testBook);

            Assert.AreEqual(testBook, dataRepository.GetBook(bookNumber));
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteBookByIdTest()
        {
            List<Book> testList = MakeBookList();
            foreach (var book in testList)
            {
                dataRepository.AddBook(book);
            }
            int bookNumber = testList.Count() - 1;
            dataRepository.DeleteBook(bookNumber);

            dataRepository.GetBook(bookNumber);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteBookByBookTest()
        {
            List<Book> testList = MakeBookList();
            foreach (var book in testList)
            {
                dataRepository.AddBook(book);
            }
            Book testBook = dataRepository.GetBook(0);
            dataRepository.DeleteBook(testBook);

            dataRepository.GetBook(0);
        }
        #endregion BookTests

        #region BookConditionTests
        [TestMethod()]
        public void AddBookConditionTest()
        {
            BookCondition testBC = new BookCondition(new Book("Test Author", "1234567890", "Test Title", "2019"));
            dataRepository.AddBookCondition(testBC);
            Assert.AreEqual(testBC, dataRepository.GetBookCondition(0));
        }

        [TestMethod()]
        public void GetAllBooksConditionsTest()
        {
            List<BookCondition> testList = MakeBookConditionList();
            foreach (var bc in testList)
            {
                dataRepository.AddBookCondition(bc);
            }

            IEnumerable<BookCondition> result = dataRepository.GetAllBooksConditions();
            int i = 0;
            foreach (var bc in result)
            {
                Assert.AreEqual(testList[i], bc);
                i++;
            }
        }

        [TestMethod()]
        public void GetBooksConditionsAmountTest()
        {
            List<BookCondition> testList = MakeBookConditionList();
            foreach (var bc in testList)
            {
                dataRepository.AddBookCondition(bc);
            }

            Assert.AreEqual(2, dataRepository.GetBooksConditionsAmount());
        }

        [TestMethod()]
        public void UpdateBookConditionTest()
        {
            List<BookCondition> testList = MakeBookConditionList();
            foreach (var bc in testList)
            {
                dataRepository.AddBookCondition(bc);
            }
            BookCondition testBC = new BookCondition(new Book("Test 3", "1234567890", "Test 3", "1999"));
            int bcNumber = 0;
            dataRepository.UpdateBookCondition(bcNumber, testBC);

            Assert.AreEqual(testBC, dataRepository.GetBookCondition(bcNumber));
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteBookConditionByKeyTest()
        {
            List<BookCondition> testList = MakeBookConditionList();
            foreach (var bc in testList)
            {
                dataRepository.AddBookCondition(bc);
            }
            int bcNumber = testList.Count() - 1;
            dataRepository.DeleteBookCondition(bcNumber);

            dataRepository.GetBook(bcNumber);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteBookConditionByBCTest()
        {
            List<BookCondition> testList = MakeBookConditionList();
            foreach (var bc in testList)
            {
                dataRepository.AddBookCondition(bc);
            }
            BookCondition testBC = dataRepository.GetBookCondition(0);
            dataRepository.DeleteBookCondition(testBC);

            dataRepository.GetBook(0);
        }
        #endregion BookConditionTests

        #region ClientTests
        [TestMethod()]
        public void AddClientTest()
        {
            Client testClient = new Client("Test", "McTest", "0");
            dataRepository.AddClient(testClient);
            Assert.AreEqual(testClient, dataRepository.GetClient(0));
        }

        [TestMethod()]
        public void GetAllClientsTest()
        {
            List<Client> testList = MakeClientList();
            foreach (var client in testList)
            {
                dataRepository.AddClient(client);
            }

            IEnumerable<Client> result = dataRepository.GetAllClients();
            int i = 0;
            foreach (var client in result)
            {
                Assert.AreEqual(testList[i], client);
                i++;
            }
        }

        [TestMethod()]
        public void GetClientsAmountTest()
        {
            List<Client> testList = MakeClientList();
            foreach (var client in testList)
            {
                dataRepository.AddClient(client);
            }

            Assert.AreEqual(2, dataRepository.GetClientsAmount());
        }

        [TestMethod()]
        public void GetClientByIdTest()
        {
            Client testClient = new Client("Test", "McTest", "2137");
            dataRepository.AddClient(testClient);
            Assert.AreEqual(testClient, dataRepository.GetClient("2137"));
        }

        [TestMethod()]
        public void DeleteClientByIdTest()
        {
            List<Client> testList = MakeClientList();
            foreach (var client in testList)
            {
                dataRepository.AddClient(client);
            }
            string id = testList[0].ID;
            dataRepository.DeleteClient(id);

            try
            {
                dataRepository.GetClient(id);
            } catch (Exception e)
            {
                if (e.Message != "No such client.")
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void DeleteClientByClientTest()
        {
            List<Client> testList = MakeClientList();
            foreach (var client in testList)
            {
                dataRepository.AddClient(client);
            }
            Client testClient = testList[0];
            dataRepository.DeleteClient(testClient);

            try
            {
                dataRepository.GetClient(testClient.ID);
            }
            catch (Exception e)
            {
                if (e.Message != "No such client.")
                {
                    Assert.Fail();
                }
            }
        }
        #endregion ClientTests

        #region EventTests
        [TestMethod()]
        public void AddEventTest()
        {
            Event testEvent = new Event(Event.Type.Borrow, new BookCondition(new Book("", "", "", "")), new Client("", "", ""));
            dataRepository.AddEvent(testEvent);
            Assert.AreEqual(testEvent, dataRepository.GetEvent(0));
        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            List<Event> testList = MakeEventList();
            foreach (var _event in testList)
            {
                dataRepository.AddEvent(_event);
            }

            IEnumerable<Event> result = dataRepository.GetAllEvents();
            int i = 0;
            foreach (var _event in result)
            {
                Assert.AreEqual(testList[i], _event);
                i++;
            }
        }

        [TestMethod()]
        public void GetEventsAmountTest()
        {
            List<Event> testList = MakeEventList();
            foreach (var _event in testList)
            {
                dataRepository.AddEvent(_event);
            }

            Assert.AreEqual(2, dataRepository.GetEventsAmount());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEventByIdTest()
        {
            List<Event> testList = MakeEventList();
            foreach (var _event in testList)
            {
                dataRepository.AddEvent(_event);
            }
            dataRepository.DeleteEvent(1);

            dataRepository.GetEvent(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEventByEventTest()
        {
            List<Event> testList = MakeEventList();
            foreach (var _event in testList)
            {
                dataRepository.AddEvent(_event);
            }
            Event testEvent = testList[1];
            dataRepository.DeleteEvent(testEvent);

            dataRepository.GetEvent(1);
        }
        #endregion EventTests
    }
}