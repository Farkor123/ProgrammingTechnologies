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

        #endregion bookControl

        #region bookCondiotionControl


        #endregion bookConditionControl

        #region clientControl


        #endregion clientControl

        #region eventControl



        #endregion eventControl
    }
}
