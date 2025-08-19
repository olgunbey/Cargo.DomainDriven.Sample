using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Infrastructure
{
    public class RedisRepository(IRedisClientsManagerAsync redisClientsManagerAsync) : IRedisRepository
    {
        public async Task<bool> SetCacheRefreshToken(string cacheKey, List<CacheRefreshTokenDto> cacheRefreshTokenDto)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                return await client.SetAsync(cacheKey, cacheRefreshTokenDto);
            }
        }

        public async Task<CacheRefreshTokenDto?> GetRefreshToken(string refreshToken)
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                var cacheRefreshTokenDto = await client.GetAsync<List<CacheRefreshTokenDto>>("refreshToken");

                var getUserRefreshToken = cacheRefreshTokenDto.SingleOrDefault(y => y.refreshToken == refreshToken);
                if (getUserRefreshToken == null)
                    return null;

                if (getUserRefreshToken.refreshTokenLifeTime < DateTime.UtcNow)
                    return null;

                return getUserRefreshToken;
            }
        }
        public async Task<List<CacheRefreshTokenDto>> GetAllCacheRefreshToken()
        {
            await using (var client = await redisClientsManagerAsync.GetClientAsync())
            {
                return await client.GetAsync<List<CacheRefreshTokenDto>>("refreshToken");
            }
        }
    }
}
