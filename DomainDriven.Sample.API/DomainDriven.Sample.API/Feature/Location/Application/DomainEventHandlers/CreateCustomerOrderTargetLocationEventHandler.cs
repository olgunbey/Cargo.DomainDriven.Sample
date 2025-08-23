using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers
{
    public class CustomerOrderTargetLocationEventHandle(ILocationDbContext locationDbContext) : INotificationHandler<CreateCustomerOrderTargetLocationEvent>
    {
        public async Task Handle(CreateCustomerOrderTargetLocationEvent notification, CancellationToken cancellationToken)
        {
            var getCity = locationDbContext.City.Include(y=>y.Districts).Single(y => y.Id == notification.CityId);
            var customerOrderTargetLocationReadModel = new CustomerOrderTargetLocationReadModel()
            {
                Id=notification.Id,
                CityId = notification.CityId,
                CustomerId = notification.CustomerId,
                DistrictId = notification.DistrictId,
                Detail = notification.Detail,
                LocationHeader = notification.locationHeader,
                DistrictName = getCity.Districts.Single(y => y.Id == notification.DistrictId).Name,
                CityName = getCity.Name
            };
            locationDbContext.CustomerOrderTargetLocationReadModel.Add(customerOrderTargetLocationReadModel);
        }
    }
}
