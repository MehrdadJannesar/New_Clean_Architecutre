using Newtonsoft.Json.Bson;

namespace CA.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        void SetStorageValue<T>(string key, T value);
        bool Exist(string key);
        T GetStorageValue<T>(string key);
    }
}
