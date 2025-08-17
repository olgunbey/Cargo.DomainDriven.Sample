using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Events
{
    public record CreateUserCredentialEvent(Guid UserId,string Name,string Surname,string Password,bool Gender) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
