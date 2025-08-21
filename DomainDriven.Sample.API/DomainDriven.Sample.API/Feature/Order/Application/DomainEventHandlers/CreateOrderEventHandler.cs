using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;
using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.DomainEventHandlers
{
    public class CreateOrderEventHandler(IOrderDbContext orderDbContext, IPublishEndpoint publishEndpoint) : INotificationHandler<CreateOrderEvent>
    {
        public async Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
        {
            var orderProductModel = notification.ProductItems.Select(product => new OrderProductReadModel
            {
                OrderId = notification.OrderId,
                ProductId = product.ProductId,
                Count = product.Count,
                ProductName = product.ProductName,
                Detail = notification.Detail
            });

            await orderDbContext.OrderProductRealModel.AddRangeAsync(orderProductModel);
            await orderDbContext.SaveChangesAsync(cancellationToken);
            await publishEndpoint.Publish(new OrderReceivedIntegrationEvent(notification.ProductItems.ToDictionary(y => y.ProductId, y => y.Count)));
        }
    }
}
