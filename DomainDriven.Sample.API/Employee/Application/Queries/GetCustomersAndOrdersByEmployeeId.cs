using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Application.Dtos;
using DomainDriven.Sample.API.Employee.Application.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Employee.Application.Queries
{
    public class GetCustomersAndOrdersByEmployeeIdRequest : IRequest<ResponseDto<List<GetAllSelectedEmloyeeResponseDto>>>
    {
        public int EmployeeId { get; set; }
    }
    public class GetCustomersAndOrdersByEmployeeIdHandler(IEmployeeDbContext employeeDbContext) : IRequestHandler<GetCustomersAndOrdersByEmployeeIdRequest, ResponseDto<List<GetAllSelectedEmloyeeResponseDto>>>
    {
        public async Task<ResponseDto<List<GetAllSelectedEmloyeeResponseDto>>> Handle(GetCustomersAndOrdersByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            var getAllSelectedEmployee = await employeeDbContext.GetDbSet<Domain.Aggregates.ApprovedCargoEmployee>().AsNoTracking()
                  .Where(y => y.EmployeeId == request.EmployeeId).ToListAsync();


            //List<int> orderIdOfgetAllSelectedEmployee = getAllSelectedEmployee.Select(x => x.OrderId).ToList();
            //var getOrderInformationById = await employeeRedisConsumer.GetOrderInformationByIdAsync(orderIdOfgetAllSelectedEmployee);


            //List<int> customerIdOfgetAllSelectedEmployee = getOrderInformationById.Select(y => y.CustomerId).ToList();
            //var getCustomerInformationById = await employeeRedisConsumer.GetCustomerInformationByIdAsync(customerIdOfgetAllSelectedEmployee);



            //var responseData = getOrderInformationById.Select(y => new GetAllSelectedEmloyeeResponseDto()
            //{
            //    OrderDto = y.OrderItems.Select(x => new OrderDto()
            //    {
            //        CustomerDto = new CustomerDto()
            //        {
            //            Id = getCustomerInformationById.Single(c => c.Id == y.CustomerId).Id,
            //            CurrentLocation = new LocationDto()
            //            {
            //                CityId = getCustomerInformationById.Single(c => c.Id == y.CustomerId).Location.CityId,
            //                DistrictId = getCustomerInformationById.Single(c => c.Id == y.CustomerId).Location.DistrictId,
            //                Detail = getCustomerInformationById.Single(c => c.Id == y.CustomerId).Location.Detail
            //            }
            //        },
            //        OrderItems = y.OrderItems.Select(o => new OrderItemDto()
            //        {
            //            Id = o.Id,
            //            Name = o.Name,
            //            Count = o.Count,
            //            Weight = o.Weight
            //        }).ToList(),
            //        TargetLocation = new LocationDto()
            //        {
            //            CityId = y.TargetLocation.CityId,
            //            DistrictId = y.TargetLocation.DistrictId,
            //            Detail = y.TargetLocation.Detail
            //        }
            //    }).ToList()

            //}).ToList();


            return ResponseDto<List<GetAllSelectedEmloyeeResponseDto>>.Success(responseData);
        }
    }
}
