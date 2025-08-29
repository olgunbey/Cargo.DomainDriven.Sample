using DomainDriven.Sample.API.Feature.Order.Application.Dtos;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;

namespace DomainDriven.Sample.API.Feature.Order.Application.IntegrationEventHandlers
{
    public class CargoStatusUpdateIntegrationEventHandler(IOrderDbContext orderDbContext) : IConsumer<CargoStatusUpdateToOrderIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<CargoStatusUpdateToOrderIntegrationEvent> context)
        {
            var getAllOrderById = orderDbContext.OrderInformation
                .Where(y => y.Id == context.Message.OrderId);

            var updateOrderStatus = OrderStatusMapper.MapToDomain(context.Message.CargoStatus);
            foreach (var order in getAllOrderById)
            {
                order.UpdateStatus(updateOrderStatus);
            }
            await orderDbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
