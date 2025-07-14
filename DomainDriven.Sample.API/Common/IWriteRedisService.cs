namespace DomainDriven.Sample.API.Common
{
    public interface IWriteRedisService<in T> where T : class
    {
        public Task AddOrUpdate<T>(string key, T value);
    }
}
