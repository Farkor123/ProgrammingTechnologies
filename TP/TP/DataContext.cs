using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP
{
    public class DataContext
    {
        public List<Client> clientList;
        public Dictionary<int, Book> bookDictionary;
        public ObservableCollection<Event> eventObservableCollection;
        public List<BookCondition> bookConditionList;
    }
}
