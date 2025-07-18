using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using DomainDriven.Sample.API.Order.Domain.Aggregates;
using DomainDriven.Sample.API.Order.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Application.Commands
{
    public class OrderChooseEmployeeRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
    }
    public class OrderChooseEmployeeRequestHandler(IOrderDbContext orderDbContext, IOrderChooseEmployee orderChooseEmployee) : IRequestHandler<OrderChooseEmployeeRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(OrderChooseEmployeeRequest request, CancellationToken cancellationToken)
        {
            DbSet<OrderChooseEmployee> dbOrderChooseEmployee = orderDbContext.GetDbSet<OrderChooseEmployee>();

            var generateOrderChooseEmployee = orderChooseEmployee.GenerateOrderChooseEmployee(request.OrderId, request.EmployeeId);

            dbOrderChooseEmployee.Add(generateOrderChooseEmployee);
            await orderDbContext.SaveChangesAsync(cancellationToken);
            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
