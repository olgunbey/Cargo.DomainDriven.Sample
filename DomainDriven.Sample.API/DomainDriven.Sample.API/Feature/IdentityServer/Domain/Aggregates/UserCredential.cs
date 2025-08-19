using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Events;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates
{
    public class UserCredential : AggregateRoot
    {
        public UserCredential()
        {

        }
        public UserCredential(string mail, string password,string name,string surname,bool gender)
        {
            this.Mail = mail;
            this.Password = password;
            RaiseDomainEvent(new RegisterEvent(this.Id, name, surname, gender));
        }
        public string Mail { get; private set; }
        public string Password { get; private set; }
    }
}
