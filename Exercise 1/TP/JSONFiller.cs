using System;
using Newtonsoft.Json;
using System.IO;

namespace TP
{
    public class JSONFiller : IDataFiller
    {
        public JSONFiller() { }

        public void Fill(DataContext data)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Data\DataContext.json";
            DataContext tmp = JsonConvert.DeserializeObject<DataContext>(File.ReadAllText(path), new JsonSerializerSettings());
            foreach (var entry in tmp.bookDictionary)
            {
                data.bookDictionary.Add(entry.Key, entry.Value);
            }
            foreach (var client in tmp.clientList)
            {
                data.clientList.Add(client);
            }
            foreach (var condition in tmp.bookConditionList)
            {
                data.bookConditionList.Add(condition);
            }
            foreach (var ev in tmp.eventObservableCollection)
            {
                data.eventObservableCollection.Add(ev);
            }
        }
    }
}
