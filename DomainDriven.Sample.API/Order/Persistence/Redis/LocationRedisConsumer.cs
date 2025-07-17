using DomainDriven.Sample.API.Order.Application.Dtos;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Order.Persistence.Redis
{
    public class LocationRedisConsumer(IRedisClientsManagerAsync redisClientsManagerAsync) : ILocationRedisConsumer
    {
        public async Task<LocationCacheDto?> ConsumeAsync(string key)
        {
            await using (var redisClient = await redisClientsManagerAsync.GetClientAsync())
            {
                return await redisClient.GetAsync<LocationCacheDto>(key);
            }
        }
    }
}
