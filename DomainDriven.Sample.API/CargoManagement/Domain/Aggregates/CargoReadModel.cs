using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoReadModel : AggregateRoot, ICargoReadModel
    {
        public CargoReadModel()
        {

        }
        public int CustomerId { get; private set; }
        public string CargoCode { get; private set; }
        public Status Status { get; private set; }
        public DateTime LastUpdatedDate { get; set; }

        public CargoReadModel GenerateCargoReadModel(int customerId, string cargoCode, StatusType statusType)
        {
            this.CustomerId = customerId;
            this.CargoCode = cargoCode;
            this.Status = new Status(statusType);
            return this;
        }
        public void UpdateStatus(StatusType statusType)
        {
            this.Status = new Status(statusType);
        }
    }
}
