namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record RegisterIntegrationEvent(Guid UserId, string Name, string Surname, bool Gender)
    {
    }
}
