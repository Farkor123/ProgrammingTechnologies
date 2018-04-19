using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Serializator
    {
        string filename;
        private Dictionary<long, string> objectDictionary;
        private ObjectIDGenerator idGenerator;
        string serializationString;
        Dictionary<long, ICustomSerializable> readObjects;
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

        public List<string> GetObjectStringList(long id)
        {
            string value;
            objectDictionary.TryGetValue(id, out value);
            List<string> des = new List<string>();
            foreach (string s in value.Split(new char[] { ',' }))
            {
                des.Add(s);
            }
            return des;
        }

        public List<string> GetObjectStringList(string id)
        {
            return GetObjectStringList(ParseID(id));
        }

        private long ParseID(string id)
        {
            long index;
            Int64.TryParse(id, out index);
            return index;
        }

        public ICustomSerializable GetObject(string id)
        {
            return GetObject(ParseID(id));
        }

        public ICustomSerializable GetObject(long id)
        {
            ICustomSerializable obj;
            bool gettingDictionaryItemWasSuccesfull = readObjects.TryGetValue(id, out obj);
            if (gettingDictionaryItemWasSuccesfull)
            {
                return obj;
            }
            List<string> des = GetObjectStringList(id);

            Type t = Type.GetType("TP." + des[0]);
            ICustomSerializable c = (ICustomSerializable)Activator.CreateInstance(t);
            c.Deserialize(des, this);
            readObjects.Add(id, c);

            return c;
        }

        public void Add(ICustomSerializable obj, bool main = true)
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
            string serializationData;
            using (var file = new StreamReader(filename))
            {
                serializationString = file.ReadLine();
                serializationData = file.ReadLine();
            }

            readObjects = new Dictionary<long, ICustomSerializable>();
            objectDictionary = new Dictionary<long, string>();
            foreach (string s in serializationData.Split(new char[] { ';' }))
            {
                string desc = "";
                int counter = -1;
                foreach (string it in s.Split(new char[] { ',' }))
                {
                    counter++;
                    if(counter == 0) //id
                    {
                        continue;
                    }
                    if(counter != 1)
                    {
                        desc += ",";
                    }
                    desc += it;
                    
                }
                objectDictionary.Add(ParseID(s.Split(new char[] { ',' })[0]), desc);
            }
            readingIndex = 0;
        }

        public void SetFilename(string fn)
        {
            filename = fn;
        }

        public void Write()
        {
            string serializationData = "";
            foreach(var it in objectDictionary)
            {
                serializationData += it.Key.ToString() + "," + it.Value + ";";
            }

            using (var file = new StreamWriter(filename))
            {
                file.WriteLine(serializationString);
                file.WriteLine(serializationData);
            }
        }

        public ICustomSerializable GetNext()
        { 
            return GetObject(serializationString.Split(new char[] { ',' })[readingIndex++]);
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
