using MediatR;

namespace DomainDriven.Sample.API.Employee.Domain.Events
{
    public record CargoAssignedNotification(int EmployeeId, int CargoId) : INotification { }
}
