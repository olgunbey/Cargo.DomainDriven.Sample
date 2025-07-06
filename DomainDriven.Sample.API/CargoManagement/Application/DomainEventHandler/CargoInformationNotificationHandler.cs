using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using EventStore.Client;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Application.DomainEventHandler
{
    public class CargoInformationNotificationHandler(EventStoreClient eventStoreClient) : INotificationHandler<CargoInformationEvent>
    {
        public async Task Handle(CargoInformationEvent notification, CancellationToken cancellationToken)
        {
            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{notification.CompanyId}-{notification.OrderId}",
                 expectedRevision: StreamRevision.None,
                 cancellationToken: cancellationToken,
                 eventData: new[] {
                    new EventData(
                        eventId: Uuid.NewUuid(),
                        type: nameof(CargoInformationEvent),
                        data: System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(notification),
                        metadata: null)
                 });
        }
    }
}
