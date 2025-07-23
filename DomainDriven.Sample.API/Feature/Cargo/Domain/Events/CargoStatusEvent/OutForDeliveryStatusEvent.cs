namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record OutForDeliveryStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
