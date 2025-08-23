using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers
{
    public class RemoveCustomerOrderTargetLocationEventHandler(ILocationDbContext locationDbContext) : INotificationHandler<RemoveCustomerOrderTargetLocationEvent>
    {
        public async Task Handle(RemoveCustomerOrderTargetLocationEvent notification, CancellationToken cancellationToken)
        {
            var removeLocationReadModel = await locationDbContext.CustomerOrderTargetLocationReadModel.FindAsync(notification.LocationId);
            locationDbContext.CustomerOrderTargetLocationReadModel.Remove(removeLocationReadModel);
        }
    }
}
