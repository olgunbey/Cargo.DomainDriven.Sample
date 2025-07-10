using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Common;
using System.Text;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot, ICargo
    {
        public CargoInformation()
        {
        }
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public Status Status { get; private set; }
        public int? EmployeeId { get; private set; }
        public int OrderId { get; private set; }
        public string CargoCode { get; private set; }
        public int CompanyId { get; private set; }
        public DateTime CargoCreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public TargetLocation TargetLocation { get; private set; }

        private static string GenerateCargoCode()
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
            return result.ToString();
        }
        public void UpdateStatus(StatusType statusType)
        {
            this.Status = new Status(statusType);
            this.LastUpdatedDate = DateTime.UtcNow;
        }

        public void AssignCargoToEmployee(int senderId)
        {
            this.EmployeeId = senderId;
        }
        public CargoInformation ShallowCopy()
        {
            return (CargoInformation)MemberwiseClone();
        }

        public CargoInformation GenerateCargo(int customerId, int orderId, int companyId, int cityId, int districtId, string detail)
        {
            this.CargoCode = GenerateCargoCode();
            this.CustomerId = customerId;
            this.CompanyId = companyId;
            this.OrderId = orderId;
            this.EmployeeId = null;
            this.TargetLocation = new TargetLocation(cityId, districtId, detail);
            this.CargoCreatedDate = DateTime.UtcNow;
            this.Status = new Status(StatusType.Created);
            RaiseDomainEvent(new GenerateCargoEvent(detail, this.CargoCode));
            return this;
        }
    }
}
