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
    public class GetAllOrderByEmployeeIdRequestHandler(IOrderDbContext orderDbContext, ILocationRedisConsumer locationRedisConsumer) : IRequestHandler<GetAllOrderByEmployeeIdRequest, ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>>
    {

        public async Task<ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>> Handle(GetAllOrderByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            DbSet<Domain.Aggregates.Order> dbOrders = orderDbContext.GetDbSet<Domain.Aggregates.Order>();
            Domain.Aggregates.Order? order = await dbOrders.FindAsync(request.EmployeeId);


            var cacheLocation = await locationRedisConsumer.ConsumeAsync("Location-City");

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
                             CityName = cacheLocation!.CityDto.First(x => x.CityId == y.CustomerReadModel.LocationReadModel.CityId).CityName,
                             DistrictId = y.CustomerReadModel.LocationReadModel.DistrictId,
                             DistrictName = cacheLocation.CityDto.SelectMany(y => y.Districts).First(x => x.Id == y.CustomerReadModel.LocationReadModel.DistrictId).Name,
                             Detail = y.CustomerReadModel.LocationReadModel.Detail
                         },

                     },
                     EmployeeId = y.EmployeeId,
                     OrderId = y.OrderId
                 }).ToListAsync(cancellationToken);

            return ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>.Success(responseData, 200);

        }
    }
}
