using DomainDriven.Sample.API.Common;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Feature.Location.Infrastructure
{
    public class LocationCacheRepository(IRedisClientsManagerAsync redisClientsManagerAsync) : ICacheRepository
    {
        public async Task<T> GetCache<T>(string key)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {

                return await client.GetAsync<T>(key);
            }
        }

        public async Task SetCache<T>(string key, T value)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                await client.SetAsync(key, value);
            }
        }
    }
}
