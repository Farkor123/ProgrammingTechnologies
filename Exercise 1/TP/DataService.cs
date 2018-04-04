using static TP.DataRepository;
using System.Collections.Generic;
using System;

namespace TP
{
    public class DataService
    {
        private DataRepository repository;
        public event MyDelegate OnEventChanged;

        public DataService(DataRepository _repository)
        {
            repository = _repository;
            repository.OnEventChanged += (args) =>
            {
                OnEventChanged?.Invoke(args);
            };
            OnEventChanged = (args) =>
            {
                Console.WriteLine(args);
            };
        }

        public void Fill()
        {
            repository.UseFiller();
        }

        public void ChangeFiller(IDataFiller df)
        {
            repository.Filler = df;
        }

        #region Getters
        public Book GetBook(int key)
        {
            return repository.GetBook(key);
        }
        public BookCondition GetBookCondition(int key)
        {
            return repository.GetBookCondition(key);
        }
        public Client GetClient(int key)
        {
            return repository.GetClient(key);
        }
        public Event GetEvent(int key)
        {
            return repository.GetEvent(key);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return repository.GetAllBooks();
        }
        public IEnumerable<BookCondition> GetAllBooksConditions()
        {
            return repository.GetAllBooksConditions();
        }
        public IEnumerable<Client> GetAllClients()
        {
            return repository.GetAllClients();
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return repository.GetAllEvents();
        }
        #endregion Getters
        #region Showers
        public string ShowBook(Book book)
        {
            return book.Author + " " + book.Title + " " + book.Year + " " + book.Isbn;
        }
        public string ShowAllBooks()
        {
            string all = "";
            IEnumerable < Book > ab = GetAllBooks();
            foreach (var i in ab)
            {
                all += ShowBook(i) + "\n";
            }
            return all;
        }
        public string ShowBookCondition(BookCondition bookCondition)
        {
            return ShowBook(bookCondition.Book) + " (" + bookCondition.Condition + ")";
        }
        public string ShowAllBooksConditions()
        {
            string all = "";
            IEnumerable<BookCondition> abc = GetAllBooksConditions();
            foreach (var i in abc)
            {
                all += ShowBookCondition(i) + "\n";
            }
            return all;
        }
        public string ShowClient(Client client)
        {
            return client.FirstName + " " + client.LastName + " " + client.ID;
        }
        public string ShowAllClients()
        {
            string all = "";
            IEnumerable<Client> c = GetAllClients();
            foreach (var i in c)
            {
                all += ShowClient(i) + "\n";
            }
            return all;
        }
        public string ShowEvent(Event @event)
        {
            return @event.Action + " " + ShowBookCondition(@event.BookCondition) + " by " + ShowClient(@event.Client) + " date: " + @event.Date;
        }
        public string ShowAllEvents()
        {
            string all = "";
            IEnumerable<Event> e = GetAllEvents();
            foreach (var i in e)
            {
                all += ShowEvent(i) + "\n";
            }
            return all;
        }
        #endregion Showers
        #region Creators
        public Book CreateBook(string _author, string _isbn, string _title, string _year)
        {
            Book newBook = new Book(_author, _isbn, _title, _year);
            repository.AddBook(newBook);
            return newBook;
        }
        public BookCondition CreateBookCondition(Book book)
        {
            BookCondition newBookCondition = new BookCondition(book);
            repository.AddBookCondition(newBookCondition);
            return newBookCondition;
        }
        public Client CreateClient(string _firstName, string _lastName, string _id)
        {
            Client newClient = new Client(_firstName, _lastName, _id);
            repository.AddClient(newClient);
            return newClient;
        }
        public Event CreateEvent(Event.Type _action, BookCondition _bookCondition, Client _client)
        {
            Event newEvent = new Event(_action, _bookCondition, _client);
            repository.AddEvent(newEvent);
            return newEvent;
        }
        #endregion Creators
        #region Searchers
        public IEnumerable<Event> SearchEventsOfClient(Client client)
        {
            foreach (var ev in repository.GetAllEvents())
            {
                if (ev.Client == client)
                {
                    yield return ev;
                }
            }
        }
        public IEnumerable<Event> SearchEventsBetween(DateTime since, DateTime until)
        {
            foreach (var ev in repository.GetAllEvents())
            {
                if (ev.Date >= since && ev.Date <= until)
                {
                    yield return ev;
                }
            }
        }
        public IEnumerable<Book> SearchAvailableBooks()
        {
            foreach (var condition in repository.GetAllBooksConditions())
            {
                if (condition.Condition == BookCondition.Conditions.Available) yield return condition.Book;
            }
        }
        #endregion Searchers
        #region Deleters
        public void DeleteClient(string id)
        {
            repository.DeleteClient(id);
        }
        public void DeleteBook(int key)
        {
            repository.DeleteBook(key);
        }
        public void DeleteBook(Book book)
        {
            repository.DeleteBook(book);
        }
        public void DeleteEvent(Event ev)
        {
            repository.DeleteEvent(ev);
        }
        public void DeleteBookCondition(BookCondition condition)
        {
            repository.DeleteBookCondition(condition);
        }
        #endregion Deleters
    }
}
