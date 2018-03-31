using System;
using System.Collections.Generic;

namespace TP
{
    public class DataRepository
    {
        private DataContext dataContext;
        private IDataFiller filler;
        public delegate void MyDelegate(EventArgs args);
        public event MyDelegate OnEventChanged;

        public DataRepository(DataContext dc, IDataFiller idf)
        {
            filler = idf;
            dataContext = dc;
            dataContext.eventObservableCollection.CollectionChanged += (sender, e) =>
            {
                OnEventChanged?.Invoke(e);
            };
        }

        public void UseFiller()
        {
            filler.Fill(dataContext);
        }

        public IDataFiller Filler { get => filler; set => filler = value; }

        //C.R.U.D.
        #region bookControl

        public void AddBook(Book book)
        {
            dataContext.bookDictionary.Add((int)dataContext.bookDictionary.Count, book);
        }

        public Book GetBook(int id)
        {
            return dataContext.bookDictionary[id];
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return dataContext.bookDictionary.Values;
        }

        public int GetBooksAmount()
        {
            return dataContext.bookDictionary.Count;
        }

        public void UpdateBook(int id, Book book)
        {
            dataContext.bookDictionary[id] = book;
        }

        public void DeleteBook(int id)
        {
            foreach(var book in dataContext.bookConditionList)
            {
                if(dataContext.bookDictionary[id] == book.Book)
                {
                    throw new Exception("You can't delete this object as it's being reffered to in other class.");
                }
            }
            dataContext.bookDictionary.Remove(id);
        }

        public void DeleteBook(Book book)
        {
            foreach (var book2 in dataContext.bookConditionList)
            {
                if (book == book2.Book)
                {
                    throw new Exception("You can't delete this object as it's being reffered to in other class.");
                }
            }
            for(int id = 0; id < dataContext.bookDictionary.Count; id++)
            {
                if(dataContext.bookDictionary[id] == book)
                {
                    dataContext.bookDictionary.Remove(id);
                    return;
                }
            }
        }

        #endregion bookControl

        #region bookConditionControl
        public void AddBookCondition(BookCondition bc)
        {
            dataContext.bookConditionList.Add(bc);
        }
        public BookCondition GetBookCondition(int key)
        {
            return dataContext.bookConditionList[key];
        }
        public IEnumerable<BookCondition> GetAllBooksConditions()
        {
            return dataContext.bookConditionList;
        }
        public int GetBooksConditionsAmount()
        {
            return dataContext.bookConditionList.Count;
        }
        public void UpdateBookCondition(int key, BookCondition bc)
        {
            dataContext.bookConditionList[key] = bc;
        }
        public void DeleteBookCondition(int key)
        {
            foreach (var eventt in dataContext.eventObservableCollection)
            {
                if (eventt.BookCondition == dataContext.bookConditionList[key])
                {
                    throw new Exception("Can't delete this object as another one refers to it.");
                }
            }
            dataContext.bookConditionList.Remove(dataContext.bookConditionList[key]);
        }
        public void DeleteBookCondition(BookCondition bc)
        {
            foreach (var eventt in dataContext.eventObservableCollection)
            {
                if (eventt.BookCondition == bc)
                {
                    throw new Exception("Can't delete this object as another one refers to it.");
                }
            }
            dataContext.bookConditionList.Remove(bc);
        }
        #endregion bookConditionControl

        #region clientControl

        public void AddClient(Client client)
        {
            dataContext.clientList.Add(client);
        }

        public Client GetClient(string _id)
        {
            foreach(var client in dataContext.clientList)
            {
                if (client.ID == _id)
                {
                    return client;
                }
            }
            throw new Exception("No such client.");
        }
        public Client GetClient(int key)
        {
            return dataContext.clientList[key];
        }
        public IEnumerable<Client> GetAllClients()
        {
            return dataContext.clientList;
        }

        public int GetClientsAmount()
        {
            return dataContext.clientList.Count;
        }

        public void DeleteClient(Client client)
        {
            foreach (var clientt in dataContext.clientList)
            {
                if (clientt == client)
                {
                    dataContext.clientList.Remove(client);
                    return;
                }
            }
            throw new Exception("No such client.");
        }

        public void DeleteClient(string _id)
        {
            foreach (var client in dataContext.clientList)
            {
                if (client.ID == _id)
                {
                    dataContext.clientList.Remove(client);
                    return;
                }
            }
            throw new Exception("No such client.");
        }

        #endregion clientControl

        #region eventControl

        public void AddEvent(Event @event)
        {
            dataContext.eventObservableCollection.Add(@event);
        }

        public Event GetEvent(int id)
        {
            return dataContext.eventObservableCollection[id];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return dataContext.eventObservableCollection;
        }

        public int GetEventsAmount()
        {
            return dataContext.eventObservableCollection.Count;
        }

        public void DeleteEvent(Event @event)
        {
            foreach (var @eventt in dataContext.eventObservableCollection)
            {
                if (@eventt == @event)
                {
                    dataContext.eventObservableCollection.Remove(@event);
                    return;
                }
            }
            throw new Exception("No such event.");
        }

        public void DeleteEvent(int _id)
        {
            if(_id >= GetEventsAmount())
            {
                throw new Exception("No such event.");
            }
            dataContext.eventObservableCollection.Remove(dataContext.eventObservableCollection[_id]);
        }

        #endregion eventControl
    }
}
