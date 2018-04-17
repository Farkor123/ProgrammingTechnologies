using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP
{
    public class DataContext : ISerializablable
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

        public string GetSerializationString(Serializator serializator)
        {
            string ret = "DataContext,";
            ret += "clientList,";
            foreach(var c in clientList)
            {
                serializator.Add(c, false);
                ret += serializator.GetID(c) + ",";
            }
            ret += "bookDictionary,";
            foreach (var b in bookDictionary)
            {
                serializator.Add(b.Value, false);
                ret += b.Key.ToString() + "," + serializator.GetID(b.Value) + ",";
            }
            ret += "eventObservableCollection,";
            foreach (var e in eventObservableCollection)
            {
                serializator.Add(e, false);
                ret += serializator.GetID(e) + ",";
            }
            ret += "bookConditionList,";
            foreach (var bc in bookConditionList)
            {
                serializator.Add(bc, false);
                ret += serializator.GetID(bc) + ",";
            }
            return ret;
        }

        public void Deserialize(List<string> fields, Serializator serializator)
        {
            throw new System.NotImplementedException();
        }
    }
}
