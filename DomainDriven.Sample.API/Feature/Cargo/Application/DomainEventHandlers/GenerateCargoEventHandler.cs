using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent;
using DomainDriven.Sample.API.IntegrationEvents;
using EventStore.Client;
using MassTransit;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.DomainEventHandlers
{
    public class GenerateCargoEventHandler(EventStoreClient eventStoreClient, IPublishEndpoint publishEndpoint) : INotificationHandler<GenerateCargoEvent>
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


            await publishEndpoint.Publish(new CargoStatusUpdateIntegrationEvent(notification.OrderId, CargoStatusDto.PickedUp));
        }
    }
}
