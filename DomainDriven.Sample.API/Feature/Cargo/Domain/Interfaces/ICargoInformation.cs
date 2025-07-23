using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Interfaces
{
    public interface ICargoInformation
    {
        public CargoInformation GenerateCargo(int companyId, DateTime estimatedDateTime, int orderId);
    }
}
