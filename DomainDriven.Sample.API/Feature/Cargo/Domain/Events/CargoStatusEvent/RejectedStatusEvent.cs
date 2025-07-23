namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record RejectedStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
