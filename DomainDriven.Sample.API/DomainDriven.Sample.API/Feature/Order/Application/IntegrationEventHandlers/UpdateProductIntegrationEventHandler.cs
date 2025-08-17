using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Order.Application.IntegrationEventHandlers
{
    public class UpdateProductIntegrationEventHandler(IOrderDbContext orderDbContext) : IConsumer<UpdateProductIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<UpdateProductIntegrationEvent> context)
        {
            await orderDbContext.OrderProductRealModel.
               Where(y => y.ProductId == context.Message.ProductId)
               .ExecuteUpdateAsync(y => y.SetProperty(prop => prop.ProductName, context.Message.ProductName));
        }
    }
}
