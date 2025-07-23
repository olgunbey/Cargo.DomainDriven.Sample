namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record ReturnedStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
