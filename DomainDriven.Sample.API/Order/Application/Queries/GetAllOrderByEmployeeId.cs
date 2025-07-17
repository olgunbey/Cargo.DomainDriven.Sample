using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Application.Dtos;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using DomainDriven.Sample.API.Order.Application.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Application.Queries
{
    public class GetAllOrderByEmployeeIdRequest : IRequest<ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>>
    {
        public int EmployeeId { get; set; }
    }
    public class GetAllOrderByEmployeeIdRequestHandler(IOrderDbContext orderDbContext) : IRequestHandler<GetAllOrderByEmployeeIdRequest, ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>>
    {

        public async Task<ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>> Handle(GetAllOrderByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            DbSet<Domain.Aggregates.Order> dbOrders = orderDbContext.GetDbSet<Domain.Aggregates.Order>();
            Domain.Aggregates.Order? order = await dbOrders.FindAsync(request.EmployeeId);



            DbSet<OrderCustomerReadModel> dbOrderCustomerReadModels = orderDbContext.GetDbSet<OrderCustomerReadModel>();

            var responseData = await dbOrderCustomerReadModels
                 .AsNoTracking()
                 .Where(x => x.EmployeeId == request.EmployeeId)
                 .Select(y => new GetAllOrderByEmployeeIdResponseDto()
                 {
                     Customer = new()
                     {
                         Id = y.CustomerReadModel.Id,
                         FirstName = y.CustomerReadModel.FirstName,
                         LastName = y.CustomerReadModel.LastName,
                         Location = new()
                         {
                             CityId = y.CustomerReadModel.LocationReadModel.CityId,
                             CityName = y.CustomerReadModel.LocationReadModel.CityName,
                             DistrictId = y.CustomerReadModel.LocationReadModel.DistrictId,
                             DistrictName = y.CustomerReadModel.LocationReadModel.DistrictName,
                             Detail = y.CustomerReadModel.LocationReadModel.Detail
                         },

                     },
                     EmployeeId = y.EmployeeId,
                     OrderId = y.OrderId
                 }).ToListAsync();

            return ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>.Success(responseData, 200);

        }
    }
}
