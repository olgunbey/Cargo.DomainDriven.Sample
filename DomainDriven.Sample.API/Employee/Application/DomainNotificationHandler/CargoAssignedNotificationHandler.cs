using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Database;
using DomainDriven.Sample.API.Employee.Domain.Events;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.Employee.Application.DomainNotificationHandler
{
    public class CargoAssignedNotificationHandler(IApplicationDbContext applicationDbContext, EventStoreClient eventStoreClient) : INotificationHandler<CargoAssignedNotification>
    {
        public async Task Handle(CargoAssignedNotification notification, CancellationToken cancellationToken)
        {
            CargoInformation? cargoInformation = await applicationDbContext.GetEntity<CargoInformation>()
                  .FindAsync(notification.CargoId);

            if (cargoInformation == null)
                throw new InvalidOperationException($"Cargo with ID {notification.CargoId} not found.");

            cargoInformation.AssignCargoToEmployee(notification.EmployeeId);

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            CargoInformationEvent cargoInformationEvent = new CargoInformationEvent(
                cargoInformation.CompanyId,
                cargoInformation.CustomerId,
                cargoInformation.OrderId,
                Enum.GetName(cargoInformation.Status.StatusType)!,
                cargoInformation.CargoCode,
                notification.EmployeeId,
                cargoInformation.CargoCreatedDate,
                cargoInformation.LastUpdatedDate
                );

            var @event = new EventData(Uuid.NewUuid(), typeof(CargoInformationEvent).Name, JsonSerializer.SerializeToUtf8Bytes(cargoInformationEvent));

            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{cargoInformation.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [@event]);
        }
    }
}
