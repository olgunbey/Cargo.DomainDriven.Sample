using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class RefreshTokenControlRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenControlRequestHandler(IRedisService redisService) : IRequestHandler<RefreshTokenControlRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(RefreshTokenControlRequest request, CancellationToken cancellationToken)
        {
            bool checkRefreshToken = await redisService.CheckRefreshToken(request.RefreshToken);

            return checkRefreshToken ? ResponseDto<NoContentDto>.Success(200) : ResponseDto<NoContentDto>.Fail("Tekrar giriş yapın", 401);
        }
    }
}
