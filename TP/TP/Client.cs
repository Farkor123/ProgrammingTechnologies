namespace TP
{
    public class Client
    {
        private string firstName;

        private string lastName;

        public Client(string _firstName, string _lastName)
        {
            FirstName = _firstName;
            LastName = _lastName;
        }

        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }
    }
}
