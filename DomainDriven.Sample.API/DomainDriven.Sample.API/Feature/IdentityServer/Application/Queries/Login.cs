using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class LoginRequest : IRequest<ResponseDto<LoginResponseDto>>
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public class LoginRequestHandler(IIdentityServerDbContext identityServerDbContext, ITokenService tokenService, IRedisRepository redisService) : IRequestHandler<LoginRequest, ResponseDto<LoginResponseDto>>
    {
        public async Task<ResponseDto<LoginResponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var getCustomerReadModel = await identityServerDbContext
                .UserCredential
                .SingleOrDefaultAsync(x => x.Mail == request.Mail
                && x.Password == request.Password);

            if (getCustomerReadModel == null)
                return ResponseDto<LoginResponseDto>.Fail("Kullanıcı adı veya şifre yanlış", 401);

            var getClientCredential = await identityServerDbContext
                 .ClientCredential
                 .SingleOrDefaultAsync(y => y.ClientId == request.ClientId
                 && y.ClientSecret == request.ClientSecret);


            if (getClientCredential == null)
                return ResponseDto<LoginResponseDto>.Fail("ClientId veya ClientSecret yanlış", 401);


            var tokenResponse = tokenService.GenerateToken(getCustomerReadModel.Id, getClientCredential.Audience, getClientCredential.Issuer, getClientCredential.ClientSecret);

            var getAllCacheRefreshToken = await redisService.GetAllCacheRefreshToken();

            if (getAllCacheRefreshToken == null)
            {
                getAllCacheRefreshToken = new List<CacheRefreshTokenDto>();
            }
            getAllCacheRefreshToken.Add(new CacheRefreshTokenDto(tokenResponse.RefreshTokenLifeTime, tokenResponse.RefreshToken, tokenResponse.UserId));

            var hasCache = await redisService.SetCacheRefreshToken("refreshToken", getAllCacheRefreshToken);

            return hasCache ? ResponseDto<LoginResponseDto>.Success(tokenResponse, 200) : ResponseDto<LoginResponseDto>.Fail("Cachlenmedi!!!", 401);

        }
    }
}
