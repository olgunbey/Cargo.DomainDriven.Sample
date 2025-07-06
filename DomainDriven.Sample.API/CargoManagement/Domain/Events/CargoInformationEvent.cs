using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public record CargoInformationEvent(
    int CompanyId,
    int CustomerId,
    int OrderId,
    string Status,
    DateTime CargoCreatedDate
) : INotification;

}
