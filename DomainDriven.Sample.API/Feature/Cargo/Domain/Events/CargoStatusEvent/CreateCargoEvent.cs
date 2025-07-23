namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record CreateCargoEvent(int CompanyId, int OrderId, DateTime EstimatedDateTime, DateTime CreatedDate, string CargoCode)
    {
    }
}
