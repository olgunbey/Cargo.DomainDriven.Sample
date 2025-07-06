using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot, ICargoInformation
    {
        public CargoInformation()
        {
            base.Notifications = new List<INotification>();
        }
        public int Id { get; private set; }

        public int CustomerId { get; private set; }
        public bool IsDelivered { get; private set; } = false;

        public Status Status { get; private set; }
        public int? CargoSenderId { get; private set; }

        public int OrderId { get; private set; }

        public int CompanyId { get; private set; }
        public DateTime CargoCreatedDate { get; private set; }

        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId)
        {
            CustomerId = customerId;
            CompanyId = companyId;
            OrderId = orderId;
            CargoSenderId = null;
            CargoCreatedDate = DateTime.UtcNow;
            Status = new Status(StatusType.Created);
            base.Notifications.Add(new CargoInformationEvent(this.CompanyId, this.CustomerId, this.OrderId, Enum.GetName(StatusType.Created)!, DateTime.UtcNow, null));
            return this;
        }
        public void UpdateStatus(StatusType statusType)
        {
            Status = new Status(statusType);
            if (statusType == StatusType.Delivered)
            {
                IsDelivered = true;
            }

            base.Notifications.Add(new CargoInformationEvent(this.CompanyId, this.CustomerId, this.OrderId, Enum.GetName(statusType)!, this.CargoCreatedDate, DateTime.UtcNow));
        }

        public void SetCargoSenderId(int senderId)
        {
            this.CargoSenderId = senderId;

        }
    }
}
