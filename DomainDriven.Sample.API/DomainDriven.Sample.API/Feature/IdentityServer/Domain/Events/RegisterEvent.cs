using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Domain.Events
{
    public record RegisterEvent(Guid UserId, string Name, string Surname, bool Gender) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
