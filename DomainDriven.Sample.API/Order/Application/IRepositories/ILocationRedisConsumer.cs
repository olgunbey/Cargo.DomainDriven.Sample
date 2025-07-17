using DomainDriven.Sample.API.Order.Application.Dtos;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface ILocationRedisConsumer
    {
        public Task<LocationCacheDto?> ConsumeAsync(string key);
    }
}
