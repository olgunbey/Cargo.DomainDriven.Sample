namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record OrderReceivedIntegrationEvent(Dictionary<Guid,int> productIdCount) { }
}
