using DomainDriven.Sample.API.Employee.Application.Dtos;
using DomainDriven.Sample.API.Employee.Application.IRepositories;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Employee.Infrastructure.Redis
{
    public class LocationRedisConsumer(IRedisClientsManagerAsync redisClientsManagerAsync) : ILocationRedisConsumer
    {
        public async Task<LocationCacheDto> ConsumeAsync(string key)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                return await client.GetAsync<LocationCacheDto>(key);

            }
        }
    }
}
