namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record DeliveredStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
