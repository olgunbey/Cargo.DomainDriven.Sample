using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class RefreshTokenControlRequest : IRequest<Result<LoginResponseDto>>
    {
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenControlRequestHandler(IRedisRepository redisService, ITokenService tokenService) : IRequestHandler<RefreshTokenControlRequest, Result<LoginResponseDto>>
    {
        public async Task<Result<LoginResponseDto>> Handle(RefreshTokenControlRequest request, CancellationToken cancellationToken)
        {
            var getAllCacheRefreshToken = await redisService.GetAllCacheRefreshToken();

            var getRefreshToken = getAllCacheRefreshToken.SingleOrDefault(u => u.refreshToken == request.RefreshToken);
            if (getRefreshToken == null)
            {
                return Result<LoginResponseDto>.Fail("Unauthorized", 401);
            }

            getAllCacheRefreshToken.Remove(getRefreshToken);
            var token = tokenService.GenerateToken(Guid.Parse(getRefreshToken.userId), "https://localhost:7208", "https://localhost:7208", "testSecret");

            getAllCacheRefreshToken.Add(new Dtos.CacheRefreshTokenDto(token.RefreshTokenLifeTime, token.RefreshToken, token.UserId));
            await redisService.SetCacheRefreshToken("refreshToken", getAllCacheRefreshToken);

            return Result<LoginResponseDto>.Success(token);

        }
    }
}
