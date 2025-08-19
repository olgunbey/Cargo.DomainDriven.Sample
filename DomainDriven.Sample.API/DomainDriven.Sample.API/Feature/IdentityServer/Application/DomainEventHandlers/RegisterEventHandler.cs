using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Events;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.DomainEventHandlers
{
    public class RegisterEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<RegisterEvent>
    {
        public async Task Handle(RegisterEvent notification, CancellationToken cancellationToken)
        {
            await publishEndpoint.Publish(new RegisterIntegrationEvent(notification.UserId, notification.Name, notification.Surname, notification.Gender));
        }
    }
}
