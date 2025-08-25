using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers
{
    public class UpdateCustomerOrderTargetLocationEventHandler(ILocationDbContext locationDbContext) : INotificationHandler<UpdateCustomerLocationForOrderTargetLocationEvent>
    {
        public async Task Handle(UpdateCustomerLocationForOrderTargetLocationEvent notification, CancellationToken cancellationToken)
        {
            var readModel = await locationDbContext.CustomerOrderTargetLocationReadModel.FindAsync(notification.id);

            if (readModel == null)
                return;


            readModel.DistrictId = notification.districtId;
            readModel.CityId = notification.cityId;
            readModel.Detail = notification.detail;

            
            var city = await locationDbContext.City.Include(y => y.Districts).SingleAsync(y => y.Id == notification.cityId);
            readModel.CityName = city.Name;

            var district = city.Districts.Single(y => y.Id == notification.districtId);
            readModel.DistrictName = district.Name;

        }
    }
}
