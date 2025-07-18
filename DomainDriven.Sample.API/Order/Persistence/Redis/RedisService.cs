using DomainDriven.Sample.API.Order.Application.IRepositories;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Order.Persistence.Redis
{
    public class RedisService(IRedisClientsManagerAsync redisClientsManagerAsync) : IRedisService
    {
        public async Task<T> GetAsync<T>(string key)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                return await client.GetAsync<T>(key);
            }
        }

        public async Task Set<T>(string key, T value)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                await client.SetAsync(key, value);
            }
        }
    }
}
