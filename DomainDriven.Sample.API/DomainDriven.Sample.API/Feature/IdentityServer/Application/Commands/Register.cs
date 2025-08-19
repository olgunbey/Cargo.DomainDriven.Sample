using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Commands
{
    public class RegisterRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
    }
    public class RegisterRequestHandler(IIdentityServerDbContext identityServerDbContext) : IRequestHandler<RegisterRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var userCredential = new UserCredential(request.Mail, request.Password, request.Name, request.Surname, request.Gender);
            identityServerDbContext.UserCredential.Add(userCredential);
            await identityServerDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
