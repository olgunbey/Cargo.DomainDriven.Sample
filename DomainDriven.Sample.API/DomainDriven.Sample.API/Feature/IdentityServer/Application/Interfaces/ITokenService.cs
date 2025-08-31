using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces
{
    public interface ITokenService
    {
        LoginResponseDto ResourceOwnerCredential(Guid userId);
        public ClientCredentialDto ClientCredential();
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string ClientSecret { get; set; }
        public DateTime AccessTokenLifeTime { get; set; }
        public DateTime RefreshTokenLifeTime { get; set; }
        public void SetConfiguration(string audience, string issuer, string clientSecret, DateTime accessTokenLifeTime, DateTime refreshTokenLifeTime);
    }
}
