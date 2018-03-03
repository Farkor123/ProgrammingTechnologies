namespace TP
{
    public class Client
    {
        private string firstName;

        private string id;

        private string lastName;

        public Client(string _firstName, string _lastName, string _id)
        {
            FirstName = _firstName;
            LastName = _lastName;
            ID = _id;
        }

        public string FirstName { get => firstName; set => firstName = value; }

        public string ID { get => id; set => id = value; }

        public string LastName { get => lastName; set => lastName = value; }
    }
}
