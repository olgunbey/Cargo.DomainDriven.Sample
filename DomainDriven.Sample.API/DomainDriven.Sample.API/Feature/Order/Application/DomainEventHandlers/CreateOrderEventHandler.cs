using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;
using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
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
                Quantity = product.quantity,
                OrderStatus = notification.OrderStatus,
                Price = product.price,
                ProductId = product.id,
                ProductName = product.name,
                CustomerOrderTargetLocationId = notification.TargetLocationId,
                CityId = notification.CityId,
                CityName = notification.CityName,
                DistrictId = notification.DistrictId,
                DistrictName = notification.DistrictName,
                Detail = notification.Detail,
                OrderId = notification.OrderId,
                CustomerId = notification.CustomerId
            });

            await orderDbContext.OrderProductReadModel.AddRangeAsync(orderProductModel);
            //await publishEndpoint.Publish(new OrderReceivedIntegrationEvent(notification.ProductItems.ToDictionary(y => y.ProductId, y => y.Count)));
        }
    }
}
