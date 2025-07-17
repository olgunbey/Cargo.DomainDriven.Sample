namespace DomainDriven.Sample.API.Common
{
    public interface IWriteRedisService<T> where T : AggregateRoot
    {
        public Task AddOrUpdate(string key);
    }
}
