using System;
using System.Collections.Generic;

namespace TP
{
    public class Book : ISerializablable
    {
        private string author;

        private string isbn;

        private string title;

        private string year;

        public Book() { }

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

        public void Deserialize(List<string> fields)
        {
            author = fields[1];
            isbn = fields[2];
            title = fields[3];
            year = fields[4];
        }

        public string GetSerializationString(Serializator serializator)
        {
            return "Book," + author + "," + isbn + "," + title + "," + year;
        }

        public override string ToString()
        {
            return "Book(" + author + ", " + title + ", " + year + ", " + isbn + ")";
        }
    }
}
