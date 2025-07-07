using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Database;
using DomainDriven.Sample.API.Employee.Domain.Events;
using EventStore.Client;
using MediatR;

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

            throw new NotImplementedException();
        }
    }
}
