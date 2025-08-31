using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class RefreshTokenRenewalRequest : IRequest<Result<LoginResponseDto>>
    {
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenRenewalRequestHandler(IRedisRepository redisService, ITokenService tokenService, IOptions<TokenConf> options) : IRequestHandler<RefreshTokenRenewalRequest, Result<LoginResponseDto>>
    {
        public async Task<Result<LoginResponseDto>> Handle(RefreshTokenRenewalRequest request, CancellationToken cancellationToken)
        {

            TokenConf conf = options.Value;
            var getAllCacheRefreshToken = await redisService.GetAllCacheRefreshToken();

            if (getAllCacheRefreshToken == null)
                getAllCacheRefreshToken = new List<CacheRefreshTokenDto>();

            var getRefreshToken = getAllCacheRefreshToken.SingleOrDefault(u => u.refreshToken == request.RefreshToken);
            if (getRefreshToken == null)
            {
                return Result<LoginResponseDto>.Fail("Unauthorized", 401);
            }

            getAllCacheRefreshToken.Remove(getRefreshToken);
            tokenService.SetConfiguration(conf.Audience, conf.Issuer, conf.Secret, DateTime.UtcNow.AddMinutes(1), DateTime.UtcNow.AddDays(2));
            var token = tokenService.ResourceOwnerCredential(Guid.Parse(getRefreshToken.userId));
            getAllCacheRefreshToken.Add(new Dtos.CacheRefreshTokenDto(token.RefreshTokenLifeTime, token.RefreshToken, token.UserId));
            await redisService.SetCacheRefreshToken("refreshToken", getAllCacheRefreshToken);
            return Result<LoginResponseDto>.Success(token);

        }
    }
}
