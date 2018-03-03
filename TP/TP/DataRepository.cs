using System;
using System.Collections.Generic;

namespace TP
{
    public class DataRepository
    {
        private DataContext dataContext;
        private IDataFiller filler;

        public DataRepository(DataContext dc, IDataFiller idf)
        {
            filler = idf;
            dataContext = dc;
        }

        public void UseFiller()
        {
            filler.Fill(dataContext);
        }

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

        #region bookCondiotionControl


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
