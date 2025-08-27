using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.DomainEventHandlers
{
    public class GenerateCargoEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<GenerateCargoEvent>
    {
        public async Task Handle(GenerateCargoEvent notification, CancellationToken cancellationToken)
        {
            var addedCargoProductReadModels = notification.Products.Select(dict => new CargoProductReadModel
            {
                ProductId = dict.Key,
                ProductName = dict.Value,
                CargoId = notification.CargoId,
                CityId = notification.CityId,
                DistrictId = notification.DistrictId,
                CityName = notification.CityName,
                DistrictName = notification.DistrictName,
                Detail = notification.Detail,
            });

            //cargoDbContext.CargoProductReadModel.AddRange(addedCargoProductReadModels);
            //await cargoDbContext.SaveChangesAsync(cancellationToken);

            await publishEndpoint.Publish(new CargoStatusUpdateIntegrationEvent(notification.OrderId, CargoStatusDto.PickedUp));
        }
    }
}
