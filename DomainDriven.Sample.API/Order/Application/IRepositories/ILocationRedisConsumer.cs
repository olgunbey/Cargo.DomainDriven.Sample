using DomainDriven.Sample.API.Order.Application.Dtos;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface ILocationRedisConsumer
    {
        public Task<LocationReadCacheDto?> ConsumeAsync(string key);
    }
}
