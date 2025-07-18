using DomainDriven.Sample.API.Order.Application.IRepositories;
using DomainDriven.Sample.API.Order.Application.ReadModels;
using DomainDriven.Sample.API.Order.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Application.DomainEventHandler
{
    public class GenerateOrderChooseEmployeeEventHandler(ILocationApiClient locationApiClient, ICustomerApiClient customerApiClient, IOrderDbContext orderDbContext) : INotificationHandler<GenerateOrderChooseEmployeeEvent>
    {
        public async Task Handle(GenerateOrderChooseEmployeeEvent notification, CancellationToken cancellationToken)
        {
            DbSet<OrderCustomerReadModel> dbOrderCustomerReadModel = orderDbContext.GetDbSet<OrderCustomerReadModel>();

            DbSet<Domain.Aggregates.Order> dbOrder = orderDbContext.GetDbSet<Domain.Aggregates.Order>();

            var getOrder = await dbOrder.FindAsync(notification.OrderId);
            var customerResponse = await customerApiClient.GetCustomerById(getOrder!.CustomerId);


            var customerLocation = await locationApiClient.GetLocationById(customerResponse.CurrentCityId, customerResponse.CurrentDistrictId);
            dbOrderCustomerReadModel.Add(new OrderCustomerReadModel
            {
                OrderId = notification.OrderId,
                EmployeeId = notification.EmployeeId,
                CustomerReadModel = new CustomerReadModelDto()
                {

                    FirstName = customerResponse.FirstName,
                    LastName = customerResponse.LastName,
                    PhoneNumber = customerResponse.PhoneNumber,
                    CurrentCityName = customerLocation.CityName,
                    CurrentDistrictName = customerLocation.DistrictName,
                    CurrentDetail = customerResponse.CurrentDetail
                },
                TargetLocationModel = new LocationReadModel()
                {
                    CityName = customerLocation.CityName,
                    DistrictName = customerLocation.DistrictName,
                    Detail = getOrder.TargetLocation.Detail
                }
            });
            await orderDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
