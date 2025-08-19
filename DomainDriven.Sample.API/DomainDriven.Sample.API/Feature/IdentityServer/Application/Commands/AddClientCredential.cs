using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Commands
{
    public class AddClientCredentialRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    public class AddClientCredentialRequestHandler(IIdentityServerDbContext identityServerDbContext) : IRequestHandler<AddClientCredentialRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddClientCredentialRequest request, CancellationToken cancellationToken)
        {
            var generateClientCredential = new ClientCredential(request.ClientId, request.ClientSecret, request.Issuer, request.Audience);
            identityServerDbContext.ClientCredential.Add(generateClientCredential);
            await identityServerDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success(201);
        }
    }
}
