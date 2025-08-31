using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries
{
    public class ClientCredentialRequest : IRequest<Result<ClientCredentialDto>>
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class ClientCredentialRequestHandler(ITokenService tokenService, IOptions<TokenConf> option) : IRequestHandler<ClientCredentialRequest, Result<ClientCredentialDto>>
    {
        public async Task<Result<ClientCredentialDto>> Handle(ClientCredentialRequest request, CancellationToken cancellationToken)
        {
            var conf = option.Value;

            if (request.ClientId != conf.ClientId || request.ClientSecret != conf.Secret)
                return Result<ClientCredentialDto>.Fail("Invalid client", 401);


            tokenService.SetConfiguration(conf.Audience, conf.Issuer, conf.Secret, DateTime.UtcNow.AddMinutes(1), DateTime.UtcNow.AddDays(1));

            var clientCredentialDto = tokenService.ClientCredential();

            return Result<ClientCredentialDto>.Success(clientCredentialDto);
        }
    }
}
