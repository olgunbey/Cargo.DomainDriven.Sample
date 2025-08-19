using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces
{
    public interface ITokenService
    {
        LoginResponseDto GenerateToken(Guid userId, string audience, string issuer, string clientSecret);
    }
}
