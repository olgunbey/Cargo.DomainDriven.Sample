using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class ResourceOwnerRequest : IRequest<Result<LoginResponseDto>>
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public class ResourceOwnerRequestHandler(IIdentityServerDbContext identityServerDbContext, ITokenService tokenService, IRedisRepository redisService, IOptions<TokenConf> options) : IRequestHandler<ResourceOwnerRequest, Result<LoginResponseDto>>
    {
        public async Task<Result<LoginResponseDto>> Handle(ResourceOwnerRequest request, CancellationToken cancellationToken)
        {
            var conf = options.Value;
            var getCustomerReadModel = await identityServerDbContext
                .UserCredential
                .SingleOrDefaultAsync(x => x.Mail == request.Mail
                && x.Password == request.Password);

            if (getCustomerReadModel == null)
                return Result<LoginResponseDto>.Fail("Kullanıcı adı veya şifre yanlış", 401);


            if (conf.ClientId != request.ClientId || conf.Secret != request.ClientSecret)
                return Result<LoginResponseDto>.Fail("ClientId veya ClientSecret yanlış", 401);


            tokenService.SetConfiguration(conf.Audience, conf.Issuer, conf.Secret, DateTime.UtcNow.AddMinutes(1), DateTime.UtcNow.AddDays(1));
            var tokenResponse = tokenService.ResourceOwnerCredential(getCustomerReadModel.Id);

            var getAllCacheRefreshToken = await redisService.GetAllCacheRefreshToken();

            if (getAllCacheRefreshToken == null)
            {
                getAllCacheRefreshToken = new List<CacheRefreshTokenDto>();
            }
            getAllCacheRefreshToken.Add(new CacheRefreshTokenDto(tokenResponse.RefreshTokenLifeTime, tokenResponse.RefreshToken, tokenResponse.UserId));

            var hasCache = await redisService.SetCacheRefreshToken("refreshToken", getAllCacheRefreshToken);

            return hasCache ? Result<LoginResponseDto>.Success(tokenResponse, 200) : Result<LoginResponseDto>.Fail("Cachlenmedi!!!", 401);

        }
    }
}
