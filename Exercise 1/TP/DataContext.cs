using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace TP
{
    public class DataContext : ICustomSerializable
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
            foreach(var c in clientList)
            {
                serializator.Add(c, false);
                ret += serializator.GetID(c) + ",";
            }
            ret += "endClientList,";
            foreach (var b in bookDictionary)
            {
                serializator.Add(b.Value, false);
                ret += b.Key.ToString() + "," + serializator.GetID(b.Value) + ",";
            }
            ret += "endBookDictionary,";
            foreach (var e in eventObservableCollection)
            {
                serializator.Add(e, false);
                ret += serializator.GetID(e) + ",";
            }
            ret += "endEventObservableCollection,";
            foreach (var bc in bookConditionList)
            {
                serializator.Add(bc, false);
                ret += serializator.GetID(bc) + ",";
            }
            ret += "endBookConditionList";
            return ret;
        }

        public void Deserialize(List<string> fields, Serializator serializator)
        {
            int counter = 1;
            while (fields[counter] != "endClientList")
            {
                clientList.Add((Client)serializator.GetObject(fields[counter]));
                counter++;
            }
            counter++;
            while (fields[counter] != "endBookDictionary")
            {
                bookDictionary.Add(Int32.Parse(fields[counter]), (Book)serializator.GetObject(fields[counter+1]));
                counter += 2;
            }
            counter++;
            while (fields[counter] != "endEventObservableCollection")
            {
                eventObservableCollection.Add((Event)serializator.GetObject(fields[counter]));
                counter++;
            }
            counter++;
            while (fields[counter] != "endBookConditionList")
            {
                bookConditionList.Add((BookCondition)serializator.GetObject(fields[counter]));
                counter++;
            }
        }
    }
}
