using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICargoInformation
    {
        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId);
        public void UpdateStatus(StatusType statusType);
    }
}
