using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Application.Dtos
{
    public class AddCargoEventResponseDto
    {
        public AddCargoEventResponseDto(int customerId, Status status, int employeeId, int orderId, string cargoCode, int companyId, DateTime cargoCreatedDate, DateTime lastUpdatedDate)
        {
            CustomerId = customerId;
            Status = status;
            EmployeeId = employeeId;
            OrderId = orderId;
            CargoCode = cargoCode;
            CompanyId = companyId;
            CargoCreatedDate = cargoCreatedDate;
            LastUpdatedDate = lastUpdatedDate;
        }
        public int CustomerId { get; private set; }
        public Status Status { get; private set; }
        public int? EmployeeId { get; private set; }
        public int OrderId { get; private set; }
        public string CargoCode { get; private set; }
        public int CompanyId { get; private set; }
        public DateTime CargoCreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
    }
}
