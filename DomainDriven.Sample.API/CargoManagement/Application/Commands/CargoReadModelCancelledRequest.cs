using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class CargoReadModelCancelledRequest : IRequest
    {
        public string CargoCode { get; set; }
    }
    public class CargoReadModelCancelledRequestHandler(ICargoManagementDbContext cargoManagementDbContext) : IRequestHandler<CargoReadModelCancelledRequest>
    {
        public async Task Handle(CargoReadModelCancelledRequest request, CancellationToken cancellationToken)
        {
            CargoReadModel? cargoReadModel = await cargoManagementDbContext.GetDbSet<CargoReadModel>()
                   .FirstOrDefaultAsync(y => y.CargoCode == request.CargoCode, cancellationToken: cancellationToken);

            if (cargoReadModel == null)
            {
                throw new KeyNotFoundException($"Cargo with code {request.CargoCode} not found.");
            }

            cargoReadModel.UpdateStatus(Domain.ValueObjects.StatusType.Cancelled);
            await cargoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
