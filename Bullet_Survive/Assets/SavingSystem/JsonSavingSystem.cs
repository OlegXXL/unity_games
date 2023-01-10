using Newtonsoft.Json;
using SavingSystems.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace SavingSystems.Systems
{
    public class JsonSavingSystem<T> : IDataSaver<T>
    {
        public void SaveObject(T savingObject, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObject, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveObjects(T[] savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveListObjects(List<T> savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveDictionaryObjects(Dictionary<T, T> savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public T LoadObject(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public T[] LoadObjects(string path)
        {
            return JsonConvert.DeserializeObject<T[]>(File.ReadAllText(path));
        }

        public List<T> LoadListObjects(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }

        public Dictionary<T,T> LoadDictionaryObjects(string path)
        {
            return JsonConvert.DeserializeObject<Dictionary<T, T>>(File.ReadAllText(path));
        }
    }
}
