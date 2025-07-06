using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICargoInformation
    {
        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId);
    }
}
