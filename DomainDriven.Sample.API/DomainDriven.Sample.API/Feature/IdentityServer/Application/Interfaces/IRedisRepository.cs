using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces
{
    public interface IRedisRepository
    {
        public Task<CacheRefreshTokenDto?> GetRefreshToken(string refreshToken);
        public Task<bool> SetCacheRefreshToken(string cacheKey, List<CacheRefreshTokenDto> cacheRefreshTokenDto);
        public Task<List<CacheRefreshTokenDto>?> GetAllCacheRefreshToken();
    }
}
