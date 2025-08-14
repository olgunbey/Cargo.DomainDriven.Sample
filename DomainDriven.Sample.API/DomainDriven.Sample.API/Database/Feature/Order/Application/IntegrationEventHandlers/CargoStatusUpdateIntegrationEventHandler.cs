using DomainDriven.Sample.API.Feature.Order.Application.Dtos;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;

namespace DomainDriven.Sample.API.Feature.Order.Application.IntegrationEventHandlers
{
    public class CargoStatusUpdateIntegrationEventHandler(IOrderDbContext orderDbContext) : IConsumer<CargoStatusUpdateIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<CargoStatusUpdateIntegrationEvent> context)
        {
            var getOrderById = await orderDbContext.OrderInformation.FindAsync(context.Message.OrderId);

            var updateOrderStatus = OrderStatusMapper.MapToDomain(context.Message.CargoStatus);
            getOrderById.UpdateStatus(updateOrderStatus);
            await orderDbContext.SaveChangesAsync();
        }
    }
}
