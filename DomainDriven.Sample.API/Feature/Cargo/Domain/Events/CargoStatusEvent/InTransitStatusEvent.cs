namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record InTransitStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
