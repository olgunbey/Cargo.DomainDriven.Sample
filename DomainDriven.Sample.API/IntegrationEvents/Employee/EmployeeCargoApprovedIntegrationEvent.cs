namespace DomainDriven.Sample.API.IntegrationEvents.Employee
{
    public record EmployeeCargoApprovedIntegrationEvent(int OrderId, bool Approved)
    {

    }
}
