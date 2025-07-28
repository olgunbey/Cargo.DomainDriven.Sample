namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record OrderReceivedIntegrationEvent(Dictionary<int,int> productIdCount) { }
}
