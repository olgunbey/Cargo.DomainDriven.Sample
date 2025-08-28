
using DomainDriven.Sample.API.Feature.Order.Application.Dtos;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.DomainEventHandlers
{
    public class UpdateStatusOrderEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<Domain.Events.UpdateStatusOrderEvent>
    {
        public async Task Handle(Domain.Events.UpdateStatusOrderEvent notification, CancellationToken cancellationToken)
        {
            EventOrderStatus orderStatus = OrderStatusMapper.MapToEventStatus(notification.OrderStatus);
            await publishEndpoint.Publish(new UpdateStatusAtDistributionCenterOrderEvent(notification.orderId, orderStatus));
        }
    }
}
