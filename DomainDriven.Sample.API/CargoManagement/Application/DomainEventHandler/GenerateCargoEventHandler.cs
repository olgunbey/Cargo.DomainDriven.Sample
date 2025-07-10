using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.CargoManagement.Application.DomainEventHandler
{
    public class GenerateCargoEventHandler(ICargoManagementDbContext cargoManagementDbContext, ICargoDetailInformation cargoDetailInformationService) : INotificationHandler<GenerateCargoEvent>
    {
        public async Task Handle(GenerateCargoEvent notification, CancellationToken cancellationToken)
        {
            DbSet<CargoDetailInformation> dbSetCargoDetailInformations = cargoManagementDbContext.GetDbSet<CargoDetailInformation>();
            CargoDetailInformation cargoDetailInformation = cargoDetailInformationService.GenerateCargoDetailInformation(notification.Detail, notification.CargoCode);
            dbSetCargoDetailInformations.Add(cargoDetailInformation);
            await cargoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
