using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.IntegrationEventHandlers
{
    public class UpdateProductIntegrationEventHandler() : IConsumer<UpdateProductIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<UpdateProductIntegrationEvent> context)
        {
            //await cargoDbContext.CargoProductReadModel.Where(y => y.ProductId == context.Message.ProductId)
            //     .ExecuteUpdateAsync(y => y.SetProperty(prop => prop.ProductName, context.Message.ProductName));
        }
    }
}
