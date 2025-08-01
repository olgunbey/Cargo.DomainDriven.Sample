using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Interfaces
{
    public interface ICargoInformation
    {
        public CargoInformation GenerateCargo(int companyId, DateTime estimatedDateTime, int orderId);
        public void UpdateCargoStatus(CargoStatus cargoStatus);
        public void AddProduct(IEnumerable<(int Id, string Name, int Count)> products);
    }
}
