using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public record CargoInformationNotification(
    int CompanyId,
    int CustomerId,
    int OrderId,
    string Status,
    string cargoCode,
    DateTime CargoCreatedDate,
    DateTime? CargoUpdatedDate
) : INotification;

}
