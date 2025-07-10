namespace DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore
{
    public record CargoBaseEvent(string CargoCode, int? EmpoyeeId, int CustomerId)
    {
    }
}
