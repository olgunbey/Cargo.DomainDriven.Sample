namespace DomainDriven.Sample.API.Common
{
    public interface ICacheRepository
    {
        Task SetCache<T>(string key, T value);
        Task<T> GetCache<T>(string key);
    }
}
