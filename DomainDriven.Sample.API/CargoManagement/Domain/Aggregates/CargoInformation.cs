using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Common;
using MediatR;
using System.Text;

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
        public string CargoCode { get; private set; }
        public int CompanyId { get; private set; }
        public DateTime CargoCreatedDate { get; private set; }
        public DateTime UpdateCreatedDate { get; private set; }

        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {
                if (i > 0 && i % 4 == 0)
                    result.Append('-');

                result.Append(chars[random.Next(chars.Length)]);
            }

            this.CargoCode = result.ToString();
            this.CustomerId = customerId;
            this.CompanyId = companyId;
            this.OrderId = orderId;
            this.CargoSenderId = null;
            this.CargoCreatedDate = DateTime.UtcNow;
            this.Status = new Status(StatusType.Created);
            base.Notifications.Add(new CargoInformationNotification(this.CompanyId, this.CustomerId, this.OrderId, Enum.GetName(StatusType.Created)!, this.CargoCode, DateTime.UtcNow, null));
            return this;
        }
        public void UpdateStatus(StatusType statusType)
        {
            this.Status = new Status(statusType);
            if (statusType == StatusType.Delivered)
            {
                this.IsDelivered = true;
            }

            base.Notifications.Add(new CargoInformationNotification(this.CompanyId, this.CustomerId, this.OrderId, Enum.GetName(statusType)!, this.CargoCode, this.CargoCreatedDate, DateTime.UtcNow));
        }

        public void AssignCargoToEmployee(int senderId)
        {
            this.CargoSenderId = senderId;
        }
    }
}
