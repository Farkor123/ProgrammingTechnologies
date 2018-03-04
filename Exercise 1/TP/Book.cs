namespace TP
{
    public class Book
    {
        private string author;

        private string isbn;

        private string title;

        private string year;

        public Book(string _author, string _isbn, string _title, string _year)
        {
            Author = _author;
            Isbn = _isbn;
            Title = _title;
            Year = _year;
        }

        public string Author { get => author; set => author = value; }

        public string Isbn { get => isbn; set => isbn = value; }

        public string Title { get => title; set => title = value; }

        public string Year { get => year; set => year = value; }
    }
}
