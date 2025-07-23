using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.DomainEventHandlers
{
    public class UpdateCargoStatusEventHandler(EventStoreClient eventStoreClient, ICargoDbContext cargoDbContext) : INotificationHandler<UpdateCargoStatusEvent>
    {
        public async Task Handle(UpdateCargoStatusEvent notification, CancellationToken cancellationToken)
        {
            (string type, byte[] byteSerialize) = notification.CargoStatus switch
            {
                CargoStatus.Cancelled => (typeof(CancelledStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new CancelledStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.InTransit => (typeof(InTransitStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new InTransitStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.AtDistributionCenter => (typeof(AtDistributionCenterStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new InTransitStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.OutForDelivery => (typeof(OutForDeliveryStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new OutForDeliveryStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.Delivered => (typeof(DeliveredStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new DeliveredStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.Rejected => (typeof(RejectedStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new RejectedStatusEvent(notification.UpdatedDateTime, notification.CargoCode))),
                CargoStatus.Returned => (typeof(ReturnedStatusEvent).Name, JsonSerializer.SerializeToUtf8Bytes(new ReturnedStatusEvent(notification.UpdatedDateTime, notification.CargoCode)))
            };

            EventData eventData = new(Uuid.NewUuid(), type, byteSerialize);

            var writeResult = await eventStoreClient.AppendToStreamAsync(
                  streamName: $"Cargo-{notification.CargoCode}",
                  expectedState: StreamState.Any,
                  eventData: [eventData]);


        }
    }
}
