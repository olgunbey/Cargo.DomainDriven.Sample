using DomainDriven.Sample.API.Feature.Order.Domain.Events;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.DomainEventHandlers
{
    public class CreateOrderEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<CreateOrderEvent>
    {
        public async Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
        {
            await publishEndpoint.Publish(new OrderReceivedIntegrationEvent(notification.ProductItemIds.ToDictionary(y => y.Id, y => y.Count)));
        }
    }
}
