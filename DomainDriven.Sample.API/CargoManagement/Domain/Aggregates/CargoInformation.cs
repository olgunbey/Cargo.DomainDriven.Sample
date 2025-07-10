using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Common;
using System.Text;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot, ICargoInformation
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
        public CargoInformation AddCargoInformation(int customerId, int orderId, int companyId)
        {


            this.CargoCode = GenerateCargoCode();
            this.CustomerId = customerId;
            this.CompanyId = companyId;
            this.OrderId = orderId;
            this.EmployeeId = null;
            this.CargoCreatedDate = DateTime.UtcNow;
            this.Status = new Status(StatusType.Created);
            return this;
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
    }
}
