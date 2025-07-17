using MediatR;

namespace DomainDriven.Sample.API.Employee.Domain.Events
{
    public record EmployeeCargoApprovedEvent(int OrderId, bool Approved) : INotification
    {
    }
}
