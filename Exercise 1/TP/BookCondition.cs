using System.Collections.Generic;

namespace TP
{
    public class BookCondition : ISerializablable
    {
        public enum Conditions
        {
            Available,
            Unavailable
        }

        private Conditions condition;

        private Book book;

        public BookCondition(Book _book)
        {
            Condition = Conditions.Available;
            Book = _book;
        }

        public Book Book { get => book; set => book = value; }

        public Conditions Condition { get => condition; set => condition = value; }

        public string GetSerializationString(Serializator serializator)
        {
            serializator.Add(book, false);
            return "BookCondition," + serializator.GetID(book) + "," + Condition.ToString();
        }

        public void Deserialize(List<string> fields)
        {
            throw new System.NotImplementedException();
        }
    }
}
