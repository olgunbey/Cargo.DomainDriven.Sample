using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoInformation : IAggregateRoot, ICargoInformation
    {
        public int Id { get; private set; }

        public int CustomerId { get; private set; } 
        public bool IsDelivered { get; private set; } = false;

        public Status Status { get; private set; }
        public int? CargoSenderId { get; private set; }

        public int OrderId { get; private set; } 

        public int CompanyId { get; private set; }

        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId)
        {
            CustomerId = customerId;
            CompanyId = companyId;
            OrderId = orderId;
            CargoSenderId = null;
            Status = new Status(StatusType.Created);

            return this;
        }
    }
}
