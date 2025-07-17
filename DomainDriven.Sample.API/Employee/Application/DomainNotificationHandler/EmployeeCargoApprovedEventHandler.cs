using DomainDriven.Sample.API.Employee.Domain.Events;
using MediatR;

namespace DomainDriven.Sample.API.Employee.Application.DomainNotificationHandler
{
    public class EmployeeCargoApprovedEventHandler : INotificationHandler<EmployeeCargoApprovedEvent>
    {
        public Task Handle(EmployeeCargoApprovedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
