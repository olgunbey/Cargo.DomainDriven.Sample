using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public record CargoGeneratedEvent(int CustomerId, Status Status, int? EmployeeId, int OrderId, int CompanyId, DateTime CargoCreatedDate, DateTime LastUpdatedDate, int CityId, int DistrictId, string Detail)
    {
    }
}
