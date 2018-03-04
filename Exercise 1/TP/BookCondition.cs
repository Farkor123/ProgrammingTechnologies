namespace TP
{
    public class BookCondition
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
    }
}
