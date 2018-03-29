using System;

namespace TP
{
    public class Event
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
                Console.WriteLine(value);
                switch(value)
                {
                    case Type.Borrow:
                        var x = BookCondition.Conditions.Unavailable;
                        Console.WriteLine(BookCondition);
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

    }
}
