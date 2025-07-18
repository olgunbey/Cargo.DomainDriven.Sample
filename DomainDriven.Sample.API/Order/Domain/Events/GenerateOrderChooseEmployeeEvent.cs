using MediatR;

namespace DomainDriven.Sample.API.Order.Domain.Events
{
    public record GenerateOrderChooseEmployeeEvent(int OrderId, int EmployeeId) : INotification
    {
    }
}
