using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Infrastructure
{
    public class RedisService(IRedisClientsManagerAsync redisClientsManagerAsync) : IRedisService
    {
        public async Task<bool> CacheRefreshToken(string cacheKey, CacheRefreshTokenDto cacheRefreshTokenDto)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                return await client.SetAsync(cacheKey, cacheRefreshTokenDto);
            }
        }

        public async Task<bool> CheckRefreshToken(string refreshToken)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                var cacheRefreshTokenDto = await client.GetAsync<List<CacheRefreshTokenDto>>("refreshToken");

                var getUserRefreshToken = cacheRefreshTokenDto.SingleOrDefault(y => y.refreshToken == refreshToken);
                if (getUserRefreshToken == null)
                    return false;

                if (getUserRefreshToken.refreshTokenLifeTime < DateTime.UtcNow)
                    return false;

                return true;
            }
        }
    }
}
