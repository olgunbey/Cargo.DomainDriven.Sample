using MediatR;

namespace DomainDriven.Sample.API.IntegrationEvents.Employee
{
    public record CargoAssignedToEmployeeNotification(int EmployeeId, string CargoCode) : INotification { } //rabbitmq ile kuyruk yapısıyla gidicek
}
