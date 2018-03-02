namespace TP
{
    public class ConstantFiller : IDataFiller
    {
        public ConstantFiller() { }

        public void Fill(DataContext context)
        {
            //Books
            context.bookDictionary.Add(0, new Book("Jason Matthews", "1476793764", "Palace of Treason", "2015"));
            context.bookDictionary.Add(1, new Book("Amor Towles", "0670026190", "A Gentleman in Moscow", "2016"));
            context.bookDictionary.Add(2, new Book("Harper Lee", "0061120081", "To Kill a Mockingbird", "1960"));
            context.bookDictionary.Add(3, new Book("Victoria Quinn", "1979158649", "Boss Woman", "2018"));
            context.bookDictionary.Add(4, new Book("William Cooper", "0929385225", "Behold a Pale Horse", "1991"));
            context.bookDictionary.Add(5, new Book("F. Scott Fitzgerald", "0743273567", "The Great Gatsby", "1925"));
            context.bookDictionary.Add(6, new Book("Robert Bryndza", "1910751774", "The Girl in the Ice", "2016"));
            context.bookDictionary.Add(7, new Book("Kristin Hannah", "0312577230", "The Great Alone", "2018"));
            context.bookDictionary.Add(8, new Book("Helen Hardt", "1947222201", "Shattered", "2017"));
            context.bookDictionary.Add(9, new Book("Dan Brown", "6180123268", "Origin", "2017"));

            //BookCondition
            foreach(var pos in context.bookDictionary.Values)
            {
                context.bookConditionList.Add(new BookCondition(pos));
            }

            //Clients
            context.clientList.Add(new Client("John", "Shepard"));
            context.clientList.Add(new Client("Kaidan", "Alenko"));
            context.clientList.Add(new Client("Ashley", "Williams"));
            context.clientList.Add(new Client("Garrus", "Vakarian"));
            context.clientList.Add(new Client("Wrex", "Urdnot"));
            context.clientList.Add(new Client("Mordin", "Solus"));
            context.clientList.Add(new Client("Liara", "T'Soni"));
            context.clientList.Add(new Client("Tali", "Zorah"));
            context.clientList.Add(new Client("Thane", "Krios"));
            context.clientList.Add(new Client("Miranda", "Lawson"));

            //Events
            for (int i = 0; i < 10; i++)
            {
                context.eventObservableCollection.Add(new Event(Event.Type.Borrow, context.bookConditionList[i], context.clientList[i]));
                context.eventObservableCollection.Add(new Event(Event.Type.Return, context.bookConditionList[i], context.clientList[i]));
            }
        }
    }
}