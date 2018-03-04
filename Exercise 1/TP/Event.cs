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
            Action = _action;
            BookCondition = _bookCondition;
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
                        BookCondition.Condition = BookCondition.Conditions.Unavailable;
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
