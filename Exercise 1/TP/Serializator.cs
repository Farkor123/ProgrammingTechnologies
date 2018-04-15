using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Serializator
    {
        private Dictionary<long, string> objectDictionary;
        private ObjectIDGenerator idGenerator;
        string serializationString;
        List<string> readObjects;
        int readingIndex;
        public Serializator()
        {
            serializationString = "";
            objectDictionary = new Dictionary<long, string>();
            idGenerator = new ObjectIDGenerator();
        }

        private bool IsSimple(Type type)
        {
            return type.IsPrimitive || type.Equals(typeof(string));
        }

        public long GetID(object obj)
        {
            bool firstTime;
            return idGenerator.GetId(obj, out firstTime);
        }

        public void Add(ISerializablable obj, bool main = false)
        {
            bool notExists;
            long id = idGenerator.GetId(obj, out notExists);
            if (notExists)
            {
                objectDictionary.Add(id, obj.GetSerializationString(this));
            }
            if (main)
            {
                serializationString += id + ",";
            }
        }

        public void Read()
        {
            readObjects = new List<string>();
            foreach (string s in serializationString.Split(new char[] { ',' }))
            {
                readObjects.Add(s);
            }
            readingIndex = 0;
        }

        public ISerializablable GetNext()
        {
            int index;
            Int32.TryParse(readObjects[readingIndex], out index);
            string value;
            objectDictionary.TryGetValue(index, out value);

            List<string> des = new List<string>();
            foreach(string s in value.Split(new char[] { ',' }))
            {
                des.Add(s);
            }

            Type t = Type.GetType("TP." + des[0]);
            ISerializablable c = (ISerializablable)Activator.CreateInstance(t);

            c.Deserialize(des);
            readingIndex++;
            return c;
        }

        public void Print()
        {
            Console.WriteLine(serializationString);
            foreach(var x in objectDictionary)
            {
                Console.WriteLine(x);
            }
        }
    }
}
