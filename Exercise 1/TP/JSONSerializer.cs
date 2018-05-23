using System.IO;
using Newtonsoft.Json;

namespace TP
{
    public class JSONSerializer
    {
        public T Deserialize<T>(string file)
        {
            T result;
            result = JsonConvert.DeserializeObject<T>(File.ReadAllText(file), new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            return result;
        }

        public void Serialize<T>(T obj, string file)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            }));
        }
    }
}
