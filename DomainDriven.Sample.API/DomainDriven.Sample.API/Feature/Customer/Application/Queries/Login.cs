using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Customer.Application.Queries
{
    public class LoginRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public class LoginRequestHandler(ICustomerDbContext customerDbContext) : IRequestHandler<LoginRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (await customerDbContext.UserCredential.AnyAsync(y => y.Mail == request.Mail && y.Password == request.Password))
                return ResponseDto<NoContentDto>.Success(204);

            return ResponseDto<NoContentDto>.Fail("Invalid credentials", 401);
        }
    }
}
