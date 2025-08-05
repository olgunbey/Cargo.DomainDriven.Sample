namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record UpdateProductIntegrationEvent(Guid ProductId, string ProductName) { }
}
