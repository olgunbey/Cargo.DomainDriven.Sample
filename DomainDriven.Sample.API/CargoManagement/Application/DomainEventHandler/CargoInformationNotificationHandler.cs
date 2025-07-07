using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using EventStore.Client;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Application.DomainEventHandler
{
    public class CargoInformationNotificationHandler(EventStoreClient eventStoreClient) : INotificationHandler<CargoInformationNotification>
    {
        public async Task Handle(CargoInformationNotification notification, CancellationToken cancellationToken)
        {
            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{notification.CompanyId}-{notification.OrderId}",
                 expectedRevision: StreamRevision.None,
                 cancellationToken: cancellationToken,
                 eventData: new[] {
                    new EventData(
                        eventId: Uuid.NewUuid(),
                        type: nameof(CargoInformationNotification),
                        data: System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(notification),
                        metadata: null)
                 });
        }
    }
}
