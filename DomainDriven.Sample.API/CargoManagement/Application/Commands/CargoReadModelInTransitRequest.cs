using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class CargoReadModelInTransitRequest : IRequest
    {
        public string CargoCode { get; set; }
    }
    public class CargoReadModelInTransitRequestHandler(ICargoManagementDbContext cargoManagementDbContext) : IRequestHandler<CargoReadModelInTransitRequest>
    {
        public async Task Handle(CargoReadModelInTransitRequest request, CancellationToken cancellationToken)
        {
            CargoReadModel? cargoReadModel = await cargoManagementDbContext.GetDbSet<CargoReadModel>()
                  .FirstOrDefaultAsync(y => y.CargoCode == request.CargoCode);

            if (cargoReadModel == null)
            {
                throw new KeyNotFoundException($"Cargo with ID {request.CargoCode} not found.");
            }

            cargoReadModel.UpdateStatus(StatusType.InTransit);

            await cargoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
