using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class CargoReadModelGenerateRequest : IRequest
    {
        public CargoGeneratedEvent CargoGeneratedEvent { get; set; }
    }
    public class CargoReadModelCargoGenerateRequestHandler(ICargoManagementDbContext cargoManagementDbContext) : IRequestHandler<CargoReadModelGenerateRequest>
    {
        public async Task Handle(CargoReadModelGenerateRequest request, CancellationToken cancellationToken)
        {
            cargoManagementDbContext.GetDbSet<CargoReadModel>()
                 .Add(new CargoReadModel()
                     .GenerateCargoReadModel(request.CargoGeneratedEvent.CustomerId, request.CargoGeneratedEvent.CargoCode, StatusType.Created));

            await cargoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
