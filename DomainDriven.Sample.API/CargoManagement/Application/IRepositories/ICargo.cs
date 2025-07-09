using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Application.IRepositories
{
    public interface ICargo
    {
        public CargoInformation GenerateCargo(int customerId, int orderId, int companyId, int cityId, int districtId, string detail);
        public void UpdateStatus(StatusType statusType);
        public void AssignCargoToEmployee(int senderId);
        public CargoInformation ShallowCopy();
    }
}
