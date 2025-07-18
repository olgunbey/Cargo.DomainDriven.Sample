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
    public class GetAllOrderByEmployeeIdRequestHandler(IOrderDbContext orderDbContext, IRedisService redisService) : IRequestHandler<GetAllOrderByEmployeeIdRequest, ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>>
    {

        public async Task<ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>> Handle(GetAllOrderByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            DbSet<Domain.Aggregates.Order> dbOrders = orderDbContext.GetDbSet<Domain.Aggregates.Order>();
            var cacheLocation = await redisService.GetAsync<LocationCacheDto>("Location");

            var dictCity = cacheLocation!.CityDto.ToDictionary(x => x.CityId);
            var dictDistrict = cacheLocation.CityDto.SelectMany(x => x.Districts).ToDictionary(x => x.Id);

            DbSet<OrderCustomerReadModel> dbOrderCustomerReadModels = orderDbContext.GetDbSet<OrderCustomerReadModel>();

            var orderIds = await dbOrderCustomerReadModels
                 .AsNoTracking()
                 .Where(y => y.EmployeeId == request.EmployeeId)
                 .Select(y => y.OrderId)
                 .ToListAsync();

            var orders = await orderDbContext
                .GetDbSet<Domain.Aggregates.Order>()
                .IntersectBy(orderIds, x => x.Id)
                .Include(x => x.OrderItems)
                .Select(y => new
                {
                    OrderId = y.Id,
                    y.TargetLocation,
                    OrderItems = y.OrderItems.Select(a => new GetAllOrderByEmployeeIdResponseDto.OrderItemDto
                    {
                        Name = a.Name,
                        Count = a.Count,
                        Weight = a.Weight
                    }).ToList()
                })
                .ToDictionaryAsync(y => y.OrderId);


            var responseData = await dbOrderCustomerReadModels
                .AsNoTracking()
                .Where(y => y.EmployeeId == request.EmployeeId)
                .Select(y => new GetAllOrderByEmployeeIdResponseDto()
                {
                    Order = new()
                    {
                        CustomerResponseDto = new()
                        {
                            Id = y.CustomerReadModel.Id,
                            FirstName = y.CustomerReadModel.FirstName,
                            LastName = y.CustomerReadModel.LastName,
                            PhoneNumber = y.CustomerReadModel.PhoneNumber,
                            Location = new()
                            {
                                CityId = y.CustomerReadModel.CurrentLocationModel.CityId,
                                CityName = dictCity[y.CustomerReadModel.CurrentLocationModel.CityId].CityName,
                                DistrictId = y.CustomerReadModel.CurrentLocationModel.DistrictId,
                                DistrictName = dictDistrict[y.CustomerReadModel.CurrentLocationModel.DistrictId].Name,
                                Detail = y.CustomerReadModel.CurrentLocationModel.Detail
                            }
                        },
                        TargetLocation = new()
                        {
                            CityId = orders[y.OrderId].TargetLocation.CityId,
                            CityName = dictCity[y.TargetLocationModel.CityId].CityName,
                            DistrictId = orders[y.OrderId].TargetLocation.DistrictId,
                            DistrictName = dictDistrict[y.TargetLocationModel.DistrictId].Name,
                            Detail = orders[y.OrderId].TargetLocation.Detail
                        },
                        OrderItems = orders[y.OrderId].OrderItems.ToList()
                    },
                }).ToListAsync();

            return ResponseDto<List<GetAllOrderByEmployeeIdResponseDto>>.Success(responseData, 200);

        }
    }
}
