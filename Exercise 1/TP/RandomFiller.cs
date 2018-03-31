using System;

namespace TP
{
    public class RandomFiller : IDataFiller
    {
        private int numberOfEntries;
        public RandomFiller(int NOE)
        {
            numberOfEntries = NOE;
        }

        public void Fill(DataContext data)
        {
            Random rand = new Random();
            string[] names = {"James", "John", "Robert", "Michael", "William", "David", "Richard"};
            string[] surnames = {"Smith", "Jones", "Taylor", "Brown", "Walker", "Evans", "Rodriguez"};

            for (int i = 0; i < numberOfEntries; i++)
            {
                data.bookDictionary.Add(i, new Book("Author "+rand.Next(10000), rand.Next(1000000, 9999999).ToString(), "Title "+rand.Next(10000), (1900+rand.Next(118)).ToString()));
            }
            foreach (var book in data.bookDictionary.Values)
            {
                data.bookConditionList.Add(new BookCondition(book));
            }
            for (int i = 0; i < numberOfEntries/100+10; i++)
            {
                data.clientList.Add(new Client(names[rand.Next(7)], surnames[rand.Next(7)], i.ToString()));
            }
            foreach (var client in data.clientList)
            {
                data.eventObservableCollection.Add(new Event(Event.Type.Borrow, data.bookConditionList[rand.Next(numberOfEntries)], client));
                data.eventObservableCollection.Add(new Event(Event.Type.Return, data.bookConditionList[rand.Next(numberOfEntries)], client));
            }
        }
    }
}
