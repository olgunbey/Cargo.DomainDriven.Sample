using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Infrastructure
{
    public class TokenService:ITokenService
    {
        public LoginResponseDto GenerateToken(Guid userId, string audience, string issuer, string clientSecret)
        {
            DateTime accessTokenLifeTime = DateTime.UtcNow.AddMinutes(1);
            var securityKey = new SymmetricSecurityKey(Hashing.Hash(clientSecret));

            string userIdString = userId.ToString();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userIdString)
            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var SecretToken = new JwtSecurityToken(issuer: issuer,
                audience: audience,
                claims: claims,
                expires: accessTokenLifeTime,
                signingCredentials: credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(SecretToken);

            return new LoginResponseDto()
            {
                UserId = userIdString,
                AccessToken = token,
                RefreshToken = GenerateRefreshToken,
                AccessTokenLifeTime = accessTokenLifeTime,
                RefreshTokenLifeTime = DateTime.UtcNow.AddDays(1)
            };
        }

        private string GenerateRefreshToken => Guid.NewGuid().ToString();
    }
}
