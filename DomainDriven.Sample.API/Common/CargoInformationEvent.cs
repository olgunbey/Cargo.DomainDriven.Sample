namespace DomainDriven.Sample.API.Common
{
    public record CargoInformationEvent(
    int CompanyId,
    int CustomerId,
    int OrderId,
    string Status,
    string CargoCode,
    int EmplooyeId,
    DateTime CargoCreatedDate,
    DateTime? CargoUpdatedDate
);
}
