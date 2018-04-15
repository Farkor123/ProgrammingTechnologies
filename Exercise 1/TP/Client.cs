using System.Collections.Generic;

namespace TP
{
    public class Client : ISerializablable
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

        public void Deserialize(List<string> fields)
        {
            throw new System.NotImplementedException();
        }

        public string GetSerializationString(Serializator serializator)
        {
            return "Client," + firstName + "," + lastName + "," + id;
        }

        public override string ToString()
        {
            return "Client(" + firstName + ", " + lastName + ", " + id + ")";
        }
    }
}
