namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record CancelledStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
