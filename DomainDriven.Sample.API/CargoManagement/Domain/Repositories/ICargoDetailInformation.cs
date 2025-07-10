using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICargoDetailInformation
    {
        CargoDetailInformation GenerateCargoDetailInformation(string detail, string cargoCode);
    }
}
