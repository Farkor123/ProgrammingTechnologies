using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public interface ICustomSerializable
    {
        string GetSerializationString(Serializator serializator);
        void Deserialize(List<string> fields, Serializator serializator);
    }
}
