using System.Collections.Generic;

namespace SavingSystems.Interfaces
{
    public interface IDataSaver<T>
    {
        void SaveObject(T data, string path);
        void SaveObjects(T[] data, string path);
        void SaveListObjects(List<T> data, string path);
        void SaveDictionaryObjects(Dictionary<T, T> data, string path);    

        T LoadObject(string path);
        T[] LoadObjects(string path);
        List<T> LoadListObjects(string path);
        Dictionary<T, T> LoadDictionaryObjects(string path);
    }
}
