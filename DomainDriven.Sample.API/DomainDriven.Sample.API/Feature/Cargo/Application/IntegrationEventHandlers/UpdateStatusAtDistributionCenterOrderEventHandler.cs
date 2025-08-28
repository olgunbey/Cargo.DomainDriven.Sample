using DomainDriven.Sample.API.Feature.Cargo.Application.Dtos;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.IntegrationEventHandlers
{
    public class UpdateStatusAtDistributionCenterOrderEventHandler(ICargoDbContext cargoDbContext) : IConsumer<UpdateStatusAtDistributionCenterOrderEvent>
    {
        public async Task Consume(ConsumeContext<UpdateStatusAtDistributionCenterOrderEvent> context)
        {
            var message = context.Message;
            var cargoStatus = OrderStatusMapper.MapToDto(message.EventOrderStatus);
            var createCargoInformation = new CargoInformation(message.OrderId, cargoStatus, message.CityId, message.CityName, message.DistrictId, message.DistrictName, message.detail);
            cargoDbContext.CargoInformation.Add(createCargoInformation);
            await cargoDbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
