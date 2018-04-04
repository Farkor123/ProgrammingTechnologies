using System;

namespace TP
{
    // Adds numberOfEntries books, bookConditions, 
    // 2x numberOfEntries events and numberOfClients clients
    public class RandomFiller : IDataFiller
    {
        private int numberOfEntries;
        private int numberOfClients;

        public RandomFiller(int _numberOfEntries, int _numberOfClients)
        {
            numberOfEntries = _numberOfEntries;
            numberOfClients = _numberOfClients;
        }

        public RandomFiller()
        {
            numberOfEntries = 10;
            numberOfClients = 10;
        }

        public int NumberOfEntries { get => numberOfEntries; set => numberOfEntries = value; }
        public int NumberOfClients { get => numberOfClients; set => numberOfClients = value; }

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
            for (int i = 0; i < numberOfClients; i++)
            {
                data.clientList.Add(new Client(names[rand.Next(7)], surnames[rand.Next(7)], i.ToString()));
            }
            foreach (var bc in data.bookConditionList)
            {
                Client client = data.clientList[rand.Next(numberOfClients)];
                data.eventObservableCollection.Add(new Event(Event.Type.Borrow, bc, client));
                data.eventObservableCollection.Add(new Event(Event.Type.Return, bc, client));
            }
        }
    }
}
