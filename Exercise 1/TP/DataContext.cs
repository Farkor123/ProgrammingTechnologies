using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP
{
    public class DataContext
    {
        public DataContext()
        {
            clientList = new List<Client> ();
            bookDictionary = new Dictionary<int, Book> ();
            eventObservableCollection = new ObservableCollection<Event> ();
            bookConditionList = new List<BookCondition> ();
        }

        public List<Client> clientList;
        public Dictionary<int, Book> bookDictionary;
        public ObservableCollection<Event> eventObservableCollection;
        public List<BookCondition> bookConditionList;
    }
}
