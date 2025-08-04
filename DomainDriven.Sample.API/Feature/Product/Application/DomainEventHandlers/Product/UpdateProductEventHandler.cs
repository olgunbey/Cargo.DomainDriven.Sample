using DomainDriven.Sample.API.Feature.Product.Domain.Events.Product;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Product.Application.DomainEventHandlers.Product
{
    public class UpdateProductEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<UpdateProductEvent>
    {
        public async Task Handle(UpdateProductEvent notification, CancellationToken cancellationToken)
        {
            if (notification.ShouldLogEvent)
            {
                //Save for auidit to EventStore.
            }
            await publishEndpoint.Publish(new UpdateProductIntegrationEvent(notification.ProductId, notification.ProductName));
        }
    }
}
