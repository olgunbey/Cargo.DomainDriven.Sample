using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces
{
    public interface IRedisService
    {
        public Task<bool> CheckRefreshToken(string refreshToken);

        public Task<bool> CacheRefreshToken(string cacheKey, CacheRefreshTokenDto cacheRefreshTokenDto);
    }
}
