using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoInformation : IAggregateRoot, ICargoInformation
    {
        public CargoInformation()
        {
            Notifications = new List<INotification>();
        }
        public int Id { get; private set; }

        public int CustomerId { get; private set; }
        public bool IsDelivered { get; private set; } = false;

        public Status Status { get; private set; }
        public int? CargoSenderId { get; private set; }

        public int OrderId { get; private set; }

        public int CompanyId { get; private set; }
        public List<INotification> Notifications { get; set; }

        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId)
        {
            CustomerId = customerId;
            CompanyId = companyId;
            OrderId = orderId;
            CargoSenderId = null;
            Status = new Status(StatusType.Created);

            Notifications.Add(new CargoInformationEvent()
            {
                CompanyId = companyId,
                CustomerId = customerId,
                OrderId = orderId,
                Status = Enum.GetName(StatusType.Created)!,
                CargoCreatedDate = DateTime.UtcNow,
            });

            return this;
        }
        public void UpdateStatus(StatusType statusType)
        {
            Status = new Status(statusType);
            if (statusType == StatusType.Delivered)
            {
                IsDelivered = true;
            }

            Notifications.Add(new CargoInformationEvent()
            {
                CompanyId = this.CompanyId,
                CustomerId = this.CustomerId,
                OrderId = this.OrderId,
                Status = Enum.GetName(statusType)!,
                CargoCreatedDate = DateTime.UtcNow,
            });
        }
    }
}
