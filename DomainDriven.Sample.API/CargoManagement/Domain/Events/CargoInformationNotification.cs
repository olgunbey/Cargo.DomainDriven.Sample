using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public record CargoInformationNotification(
    int CompanyId,
    int CustomerId,
    int OrderId,
    string Status,
    DateTime CargoCreatedDate,
    DateTime? CargoUpdatedDate
) : INotification;

}
