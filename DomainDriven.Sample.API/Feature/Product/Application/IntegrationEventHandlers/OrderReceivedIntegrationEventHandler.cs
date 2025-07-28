using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Product.Application.IntegrationEventHandlers
{
    public class OrderReceivedIntegrationEventHandler(IProductDbContext productDbContext) : IConsumer<OrderReceivedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<OrderReceivedIntegrationEvent> context)
        {
            await productDbContext.GetDbSet<Domain.Aggregates.Product>()
                  .IntersectBy(context.Message.productIdCount.Select(y => y.Key), x => x.Id)
                  .ExecuteUpdateAsync(x => x.SetProperty(setProperty => setProperty.Stock, x => x.Stock - context.Message.productIdCount[x.Id]));
        }
    }
}
