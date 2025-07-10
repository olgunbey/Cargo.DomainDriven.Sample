using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.IntegrationEvents.Employee;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.CargoManagement.Application.DomainHandler
{
    public class CargoAssignedToEmployeeNotificationHandler(EventStoreClient eventStoreClient) : INotificationHandler<CargoAssignedToEmployeeNotification>
    {
        public async Task Handle(CargoAssignedToEmployeeNotification notification, CancellationToken cancellationToken)
        {
            var result = await eventStoreClient.ReadStreamAsync(
                 streamName: $"Cargo-{notification.CargoCode}",
                 direction: Direction.Backwards,
                 revision: StreamPosition.End,
                 maxCount: 1
             ).SingleOrDefaultAsync(cancellationToken);


            if (result.Event == null || result.Event.Data.Length == 0)
            {
                throw new Exception("");
            }

            CargoInformation lastEvent = JsonSerializer.Deserialize<CargoInformation>(result.Event.Data.ToArray())!;

            var copyLastEvent = lastEvent.ShallowCopy();


            lastEvent.AssignCargoToEmployee(notification.EmployeeId);

            var @event = new EventData(
                Uuid.NewUuid(),
                nameof(CargoInformation),
                JsonSerializer.SerializeToUtf8Bytes(lastEvent)
            );

            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{notification.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [@event]);

        }
    }
}
