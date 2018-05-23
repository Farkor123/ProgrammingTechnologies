using System.Collections.Generic;

namespace TP
{
    public class Client : ICustomSerializable
    {
        private string firstName;

        private string id;

        private string lastName;

        public Client() { }

        public Client(string _firstName, string _lastName, string _id)
        {
            FirstName = _firstName;
            LastName = _lastName;
            ID = _id;
        }

        public string FirstName { get => firstName; set => firstName = value; }

        public string ID { get => id; set => id = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public void Deserialize(List<string> fields, Serializator serializator)
        {
            firstName = fields[1];
            lastName = fields[2];
            id = fields[3];
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
