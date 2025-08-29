using DomainDriven.Sample.API.Feature.Cargo.Application.Dtos;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.IntegrationEventHandlers
{
    public class UpdateStatusOrderToCargoEventHandler(ICargoDbContext cargoDbContext) : IConsumer<UpdateStatusOrderToCargoIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<UpdateStatusOrderToCargoIntegrationEvent> context)
        {
            var message = context.Message;
            var cargoStatus = OrderStatusMapper.MapToDto(message.EventOrderStatus);

            if (cargoStatus == CargoStatus.Rejected)
            {
                await cargoDbContext.CargoInformation
                    .Where(y => y.OrderId == message.OrderId)
                    .ExecuteUpdateAsync(y => y.SetProperty(prp => prp.CargoStatus, val => CargoStatus.Rejected));
            }

            var createCargoInformation = new CargoInformation(message.OrderId, cargoStatus, message.CityId, message.CityName, message.DistrictId, message.DistrictName, message.detail);
            cargoDbContext.CargoInformation.Add(createCargoInformation);
            await cargoDbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
