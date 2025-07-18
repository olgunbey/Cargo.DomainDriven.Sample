namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface IRedisService
    {
        public Task Set<T>(string key, T value);
        public Task<T> GetAsync<T>(string key);
    }
}
