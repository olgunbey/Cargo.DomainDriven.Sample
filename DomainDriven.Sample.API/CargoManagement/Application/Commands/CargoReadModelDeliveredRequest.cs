using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class CargoReadModelDeliveredRequest : IRequest
    {
        public string CargoCode { get; set; }
    }
    public class CargoReadModelDeliveredRequestHandler(ICargoManagementDbContext cargoManagementDbContext) : IRequestHandler<CargoReadModelDeliveredRequest>
    {
        public async Task Handle(CargoReadModelDeliveredRequest request, CancellationToken cancellationToken)
        {
            CargoReadModel? cargoReadModel = await cargoManagementDbContext.GetDbSet<CargoReadModel>()
                  .FirstOrDefaultAsync(y => y.CargoCode == request.CargoCode, cancellationToken: cancellationToken);

            if (cargoReadModel == null)
            {
                throw new KeyNotFoundException($"Cargo with code {request.CargoCode} not found.");
            }

            cargoReadModel.UpdateStatus(Domain.ValueObjects.StatusType.Delivered);
            await cargoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
