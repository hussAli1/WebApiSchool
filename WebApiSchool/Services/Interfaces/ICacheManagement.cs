namespace WebApiSchool.Services.Interfaces
{
    public interface ICacheManagement
    {
        void Set(string key, object value, TimeSpan? timeSpan = null);
        object Get(string key);
        void Remove(string key);
    }
}
