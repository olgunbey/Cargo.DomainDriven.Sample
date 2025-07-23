namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events.CargoStatusEvent
{
    public record AtDistributionCenterStatusEvent(DateTime UpdatedDateTime, string CargoCode)
    {
    }
}
