using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICargoReadModel
    {
        CargoReadModel GenerateCargoReadModel(int customerId, string cargoCode, StatusType statusType);
    }
}
