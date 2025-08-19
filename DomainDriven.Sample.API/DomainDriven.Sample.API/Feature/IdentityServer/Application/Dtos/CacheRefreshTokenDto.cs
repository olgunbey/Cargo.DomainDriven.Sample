namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos
{
    public record CacheRefreshTokenDto(DateTime refreshTokenLifeTime, string refreshToken, string userId)
    {

    }
}
