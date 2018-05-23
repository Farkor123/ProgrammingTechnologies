using System;
using System.Collections.Generic;

namespace TP
{
    public class Event : ICustomSerializable
    {
        public enum Type
        {
            Borrow,
            Return
        }

        private Type action;

        private BookCondition bookCondition;

        private Client client;

        private DateTime date;

        public Event() { }

        public Event(Type _action, BookCondition _bookCondition, Client _client)
        {
            BookCondition = _bookCondition;
            Action = _action;
            Client = _client;
            Date = DateTime.Now;
        }

        public Type Action
        {
            get => action;
            set
            {
                switch(value)
                {
                    case Type.Borrow:
                        var x = BookCondition.Conditions.Unavailable;
                        BookCondition.Condition = x;//BookCondition.Conditions.Unavailable;
                        break;
                    case Type.Return:
                        BookCondition.Condition = BookCondition.Conditions.Available;
                        break;
                }
                action = value;
            }
        }

        public BookCondition BookCondition { get => bookCondition; set => bookCondition = value; }

        public Client Client { get => client; set => client = value; }

        public DateTime Date { get => date; set => date = value; }

        public override string ToString()
        {
            return "Event(" + action + ", " + bookCondition.Book + ", " + client + ", " + date + ")";
        }

        public string GetSerializationString(Serializator serializator)
        {
            serializator.Add(Client, false);
            serializator.Add(BookCondition, false);
            return "Event," + action.ToString()
                + "," + serializator.GetID(bookCondition)
                + "," + serializator.GetID(client)
                + "," + date.ToString();
        }

        public void Deserialize(List<string> fields, Serializator serializator)
        {
            if(fields[1] == "Borrow")
            {
                action = Type.Borrow;
            }
            else
            {
                action = Type.Return;
            }
            bookCondition = (BookCondition)serializator.GetObject(fields[2]);
            client = (Client)serializator.GetObject(fields[3]);
            date = DateTime.Parse(fields[4]);
        }
    }
}
