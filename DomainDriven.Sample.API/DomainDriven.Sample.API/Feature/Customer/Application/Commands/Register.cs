using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Customer.Application.Commands
{
    public class RegisterRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
    }
    public class RegisterRequestHandler(ICustomerDbContext customerDbContext) : IRequestHandler<RegisterRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var userCredential = new UserCredential(request.Mail, request.Mail, request.Name, request.Surname, request.Gender);
            try
            {
                customerDbContext.UserCredential.Add(userCredential);
                await customerDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return ResponseDto<NoContentDto>.Fail(e.Message, 500);
            }
            return ResponseDto<NoContentDto>.Success(201);
        }
    }
}
