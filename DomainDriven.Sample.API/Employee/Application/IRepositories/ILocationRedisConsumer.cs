using DomainDriven.Sample.API.Employee.Application.Dtos;

namespace DomainDriven.Sample.API.Employee.Application.IRepositories
{
    public interface ILocationRedisConsumer
    {
        public Task<LocationCacheDto> ConsumeAsync(string key);
    }
}
