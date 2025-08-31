using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Infrastructure
{
    public class TokenService : ITokenService
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string ClientSecret { get; set; }
        public DateTime AccessTokenLifeTime { get; set; }
        public DateTime RefreshTokenLifeTime { get; set; }
        public void SetConfiguration(string audience, string issuer, string clientSecret, DateTime accessTokenLifeTime, DateTime refreshTokenLifeTime)
        {
            this.Audience = audience;
            this.Issuer = issuer;
            this.ClientSecret = clientSecret;
            this.AccessTokenLifeTime = accessTokenLifeTime;
            this.RefreshTokenLifeTime = refreshTokenLifeTime;
        }
        public LoginResponseDto ResourceOwnerCredential(Guid userId)
        {
            string userIdString = userId.ToString();
            List<Claim> claims = new()
            {
                {new(ClaimTypes.NameIdentifier,userIdString) }
            };
            var generateToken = GenerateToken(claims);
            return new LoginResponseDto()
            {
                UserId = userIdString,
                AccessToken = generateToken.AcessToken,
                RefreshToken = GenerateRefreshToken,
                AccessTokenLifeTime = generateToken.AccessTokenLifeTime,
                RefreshTokenLifeTime = RefreshTokenLifeTime
            };
        }
        public ClientCredentialDto ClientCredential()
        {
            var generateToken = GenerateToken();
            return new ClientCredentialDto()
            {
                AccessToken = generateToken.AcessToken,
                AccessTokenLifeTime = generateToken.AccessTokenLifeTime,
            };
        }

        private GenerateTokenDto GenerateToken(List<Claim> claims = default)
        {
            var securityKey = new SymmetricSecurityKey(Hashing.Hash(ClientSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var SecretToken = new JwtSecurityToken(issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: AccessTokenLifeTime,
                signingCredentials: credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(SecretToken);

            return new GenerateTokenDto()
            {
                AcessToken = token,
                AccessTokenLifeTime = AccessTokenLifeTime,
            };
        }



        private string GenerateRefreshToken => Guid.NewGuid().ToString();


    }
}
