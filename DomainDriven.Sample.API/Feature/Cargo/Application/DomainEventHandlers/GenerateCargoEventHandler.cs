using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.DomainEventHandlers
{
    public class GenerateCargoEventHandler(EventStoreClient eventStoreClient) : INotificationHandler<GenerateCargoEvent>
    {
        public async Task Handle(GenerateCargoEvent notification, CancellationToken cancellationToken)
        {
            var byteSerializerData = JsonSerializer.SerializeToUtf8Bytes(new CreateCargoEvent(
                notification.CompanyId,
                notification.OrderId,
                notification.EstimatedDateTime,
                notification.CreatedDate,
                notification.CargoCode
                ));
            EventData eventData = new EventData(Uuid.NewUuid(), typeof(CreateCargoEvent).Name, byteSerializerData);

            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{notification.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [eventData]);
        }
    }
}
